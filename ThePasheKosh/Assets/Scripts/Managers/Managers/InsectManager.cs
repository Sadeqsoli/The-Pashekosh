using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectManager : Singleton<InsectManager>
{
    #region Public Variables
    public Transform[] badInsectsSpawnPoints;
    public Transform[] goodInsectsSpawnPoints;

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
            if (Random.value < _badInsectsPercentage)
            {
                int randomInsectIndex = Random.Range(0, _nameOfBadInsects.Length);
                string insectName = _nameOfBadInsects[randomInsectIndex];

                int randomPosIndex = Random.Range(0, badInsectsSpawnPoints.Length);
                Transform pos = badInsectsSpawnPoints[randomPosIndex];

                Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
                newInsect = Pool.InstantiateGameObjectByName(insectName, pos.position, rot);
            }
            else
            {
                int randomInsectIndex = Random.Range(0, _nameOfGoodInsects.Length);
                string insectName = _nameOfGoodInsects[randomInsectIndex];

                int randomPosIndex = Random.Range(0, badInsectsSpawnPoints.Length);
                Transform pos = badInsectsSpawnPoints[randomPosIndex];

                Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
                newInsect = Pool.InstantiateGameObjectByName(insectName, pos.position, rot);
            }

            Insect insectComponent = newInsect.GetComponent<Insect>();
            if (insectComponent.isBadInsect) {
                insectComponent.Initialize(cakePoint.position, _speedOfInsects, _rotationSpeedOfInsects, _randomDirectionPercent);
            }
            else
            {

            }

            _existedInsects.Add(newInsect);

            yield return new WaitForSeconds(_timeBetweenSpawns);
        }
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
