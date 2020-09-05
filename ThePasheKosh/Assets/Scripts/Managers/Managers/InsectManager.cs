using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnTargetPointsStruct
{
    public Transform spawnPoint;
    public Transform[] targetPoints;
}

public class InsectManager : Singleton<InsectManager>
{
    #region Public Variables
    public SpawnTargetPointsStruct[] badInsectsPoints;
    public SpawnTargetPointsStruct[] goodInsectsPoints;

    #endregion

    #region Private Variables
    string[] _nameOfBadInsects;
    string[] _nameOfGoodInsects;

    float _badInsectsPercentage;
    float _timeBetweenSpawns;
    float _speedOfInsects;
    float _rotationSpeedOfInsects;
    float _randomDirectionPercent;

    List<Coroutine> _allSpawnCoroutines;
    List<GameObject> _existedInsects;

    #endregion

    protected override void Awake()
    {
        base.Awake();
        _allSpawnCoroutines = new List<Coroutine>();
        _existedInsects = new List<GameObject>();
    }

    public void StartInsectSpawning(LevelParametersStruct levelParameters)
    {
        EventManager.StartListening("InsectKilled", RemoveInsect);

        _nameOfGoodInsects = levelParameters.goodInsectsNames;
        _nameOfBadInsects = levelParameters.badInsectsNames;
        _timeBetweenSpawns = levelParameters.timeBetweenSpawns;
        _badInsectsPercentage = levelParameters.badInsectsPercentage;

        _speedOfInsects = levelParameters.speedOfInsects;
        _rotationSpeedOfInsects = levelParameters.rotationSpeedOfInsects;
        _randomDirectionPercent = levelParameters.randomDirectionPercentage;

        Coroutine newCoroutine = StartCoroutine(SpawnCoroutine());
        _allSpawnCoroutines.Add(newCoroutine);
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            GameObject newInsect;
            Transform spawnPoint;
            Transform targetPoint;
            if (Random.value < _badInsectsPercentage)
            {
                string insectName = GetRandomItem<string>(_nameOfBadInsects);

                GetSpawnTargetPoints(badInsectsPoints, out spawnPoint, out targetPoint);
                
                Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0, 360));
                newInsect = Pool.InstantiateGameObjectByName(insectName, spawnPoint.position, randomRot);
            }
            else
            {
                string insectName = GetRandomItem<string>(_nameOfGoodInsects);

                GetSpawnTargetPoints(goodInsectsPoints, out spawnPoint, out targetPoint);

                Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0, 360));
                newInsect = Pool.InstantiateGameObjectByName(insectName, spawnPoint.position, randomRot);
            }

            Insect insectComponent = newInsect.GetComponent<Insect>();
            if (insectComponent.isBadInsect) {
                insectComponent.Initialize(targetPoint.position, _speedOfInsects, _rotationSpeedOfInsects, _randomDirectionPercent);
            }
            else
            {
                insectComponent.Initialize(targetPoint.position, _speedOfInsects/1.2f, 30, 0.5f);
            }

            _existedInsects.Add(newInsect);

            yield return new WaitForSeconds(_timeBetweenSpawns);
        }
    }

    void GetSpawnTargetPoints(SpawnTargetPointsStruct[] STPS, out Transform spawnPoint, out Transform targetPoint)
    {
        int randomPosIndex = Random.Range(0, STPS.Length);
        int randomTargetPosIndex = Random.Range(0, STPS[randomPosIndex].targetPoints.Length);
        spawnPoint = STPS[randomPosIndex].spawnPoint;
        targetPoint = STPS[randomPosIndex].targetPoints[randomTargetPosIndex];
    }

    T GetRandomItem<T>(T[] input)
    {
        int randomIndex = Random.Range(0, input.Length);
        T output = input[randomIndex];
        return output;
    }

    void RemoveInsect(GameObject insect)
    {
        _existedInsects.Remove(insect);
    }

    public void StopAllSpawn(bool removeInsects)
    {
        while (_allSpawnCoroutines.Count > 0)
        {
            StopCoroutine(_allSpawnCoroutines[_allSpawnCoroutines.Count - 1]);
            _allSpawnCoroutines.RemoveAt(_allSpawnCoroutines.Count - 1);
        }
        if (removeInsects) RemoveInsects();
    }

    public void RemoveInsects()
    {
        StartCoroutine(RemoveInsectsCoroutine());
    }

    IEnumerator RemoveInsectsCoroutine()
    {
        while(_existedInsects.Count > 0)
        {
            Insect insectComponent = _existedInsects[_existedInsects.Count - 1].GetComponent<Insect>();
            insectComponent.removeInsect();
            _existedInsects.RemoveAt(_existedInsects.Count - 1);
            yield return new WaitForEndOfFrame();
        }
    }
    

}
