using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectManager : Singleton<InsectManager>
{
    #region Public Variables
    public SpawnPoint[] spawnPoints;

    public Transform cakePoint;

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


    public void RemoveInsects()
    {
        StartCoroutine(RemoveInsectsCoroutine());
    }
    public void RemoveInsect(GameObject insect)
    {
        _existedInsects.Remove(insect);
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

            Collider2D[] targetColliders;
            Insect insectComponent;

            if (Random.value < _badInsectsPercentage)
            {
                string insectName = GetRandomItem<string>(_nameOfBadInsects);

                SpawnPoint newSpawnPoint = GetRandomItem<SpawnPoint>(spawnPoints);
                Vector2 SpawnPos = newSpawnPoint.gameObject.transform.position;

                Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0, 360));
                newInsect = Pool.InstantiateGameObjectByName(insectName, SpawnPos, randomRot);

                insectComponent = newInsect.GetComponent<Insect>();
                insectComponent.Initialize(cakePoint.position, null, _speedOfInsects, _rotationSpeedOfInsects, _randomDirectionPercent);
            }
            else
            {
                string insectName = GetRandomItem<string>(_nameOfGoodInsects);

                GetSpawnTargetPoints(spawnPoints, out spawnPoint, out targetPoint, out targetColliders);

                Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0, 360));
                newInsect = Pool.InstantiateGameObjectByName(insectName, spawnPoint.position, randomRot);

                insectComponent = newInsect.GetComponent<Insect>();
                insectComponent.Initialize(targetPoint.position, targetColliders, _speedOfInsects / 1.2f, 30, 0.1f);
            }

            _existedInsects.Add(newInsect);

            yield return new WaitForSeconds(_timeBetweenSpawns);
        }
    }

    void GetSpawnTargetPoints(SpawnPoint[] spawnPointArray,
        out Transform spawnPoint, out Transform targetPoint, out Collider2D[] targetColliders)
    {
        int randomPosIndex = Random.Range(0, spawnPointArray.Length);
        int randomTargetPosIndex = Random.Range(0, spawnPointArray[randomPosIndex].targetCollider.Length);
        spawnPoint = spawnPointArray[randomPosIndex].gameObject.transform;
        targetPoint = spawnPointArray[randomPosIndex].targetCollider[randomTargetPosIndex].gameObject.transform;
        targetColliders = spawnPointArray[randomPosIndex].targetCollider;
    }

    T GetRandomItem<T>(T[] input)
    {
        int randomIndex = Random.Range(0, input.Length);
        T output = input[randomIndex];
        return output;
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


    IEnumerator RemoveInsectsCoroutine()
    {
        while(_existedInsects.Count > 0)
        {
            Insect insectComponent = _existedInsects[_existedInsects.Count - 1].GetComponent<Insect>();
            insectComponent.RemoveInsect();
            _existedInsects.RemoveAt(_existedInsects.Count - 1);
            yield return new WaitForEndOfFrame();
        }
    }
    

}
