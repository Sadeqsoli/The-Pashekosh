using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : Singleton<FlySpawner>
{
    string[] nameOfBadInsects;
    string[] nameOfGoodInsects;

    float goodInsectsPercentage;

    List<Coroutine> _allSpawnCoroutines;

    public void SetParameters(string[] nameOfGoodInsects, string[] nameOfBadInsects)
    {
        this.nameOfGoodInsects = nameOfGoodInsects;
        this.nameOfBadInsects = nameOfBadInsects;
    }

    protected override void Awake()
    {
        base.Awake();
        _allSpawnCoroutines = new List<Coroutine>();
    }

    public void StartFlySpawn(string nameOfObjectInPool, float timeBetweenSpawns, List<Transform> startPoints)
    {
        _allSpawnCoroutines.Add(StartCoroutine(SpawnCoroutine(nameOfObjectInPool, timeBetweenSpawns, startPoints)));
    }
    public void StopAllSpawn()
    {
        while(_allSpawnCoroutines.Count > 0)
        {
            StopCoroutine(_allSpawnCoroutines[_allSpawnCoroutines.Count - 1]);
            _allSpawnCoroutines.RemoveAt(_allSpawnCoroutines.Count - 1);
        }
    }

    IEnumerator SpawnCoroutine(string nameOfObjectInPool, float timeBetweenSpawns, List<Transform> startPoints)
    {
        int randomIndex;
        while (true)
        {
            randomIndex = Random.Range(0, startPoints.Count);
            GameObject gameObject = Pool.InstantiateGameObjectByName(nameOfObjectInPool, startPoints[randomIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
