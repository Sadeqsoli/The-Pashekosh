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
        string[] nameOfGoodInsects = levelParameters.goodInsectsNames;
        string[] nameOfBadInsects = levelParameters.badInsectsNames;
        float timeBetweenSpawns = levelParameters.timeBetweenSpawns;
        float badInsectsPercentage = levelParameters.badInsectsPercentage;
        SetParameters(nameOfGoodInsects, nameOfBadInsects, timeBetweenSpawns, badInsectsPercentage);
        _allSpawnCoroutines.Add(StartCoroutine(SpawnCoroutine()));
    }

    void SetParameters(string[] nameOfGoodInsects, string[] nameOfBadInsects, float timeBetweenSpawns, float badInsectsPercentage)
    {
        _nameOfGoodInsects = nameOfGoodInsects;
        _nameOfBadInsects = nameOfBadInsects;
        _timeBetweenSpawns = timeBetweenSpawns;
        _badInsectsPercentage = badInsectsPercentage;
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

                newInsect = Pool.InstantiateGameObjectByName(insectName, pos.position, Quaternion.identity);
            }
            else
            {
                int randomInsectIndex = Random.Range(0, _nameOfGoodInsects.Length);
                string insectName = _nameOfGoodInsects[randomInsectIndex];

                int randomPosIndex = Random.Range(0, badInsectsSpawnPoints.Length);
                Transform pos = badInsectsSpawnPoints[randomPosIndex];

                newInsect = Pool.InstantiateGameObjectByName(insectName, pos.position, Quaternion.identity);
            }
            Insect insectComponent = newInsect.GetComponent<Insect>();
            if (insectComponent.isBadInsect) {
                insectComponent.Initialize(cakePoint.position, 1);
            }
            else
            {
            }
            _existedInsects.Add(newInsect);
            yield return new WaitForSeconds(_timeBetweenSpawns);
        }
    }

    public void StopAllSpawn()
    {
        while (_allSpawnCoroutines.Count > 0)
        {
            StopCoroutine(_allSpawnCoroutines[_allSpawnCoroutines.Count - 1]);
            _allSpawnCoroutines.RemoveAt(_allSpawnCoroutines.Count - 1);
        }
    }

}
