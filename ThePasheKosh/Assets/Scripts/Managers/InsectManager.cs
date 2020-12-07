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

        // Bad Insect Coroutine
        Coroutine badCoroutine = StartCoroutine(SpawnCoroutine(levelParameters.badInsectParameters, true));
        _allSpawnCoroutines.Add(badCoroutine);

        Coroutine goodCoroutine = StartCoroutine(SpawnCoroutine(levelParameters.goodInsectPrarmeters, false));
        _allSpawnCoroutines.Add(badCoroutine);
        // GoodInsectCoroutine


    }

    IEnumerator SpawnCoroutine(InsectParameters insectParams, bool isBadInsect)
    {
        yield return new WaitForSeconds(Random.Range(0, insectParams.timeBetweenSpawn.max));
        while (true)
        {
            GameObject newInsect;

            string insectName = GetRandomItem<string>(insectParams.insectsName);

            SpawnPoint newSpawnPoint = GetRandomItem<SpawnPoint>(spawnPoints);
            Vector2 spawnPos = newSpawnPoint.gameObject.transform.position;

            float randomSpeed = Random.Range(insectParams.insectSpeed.min, insectParams.insectSpeed.max);
            float randomRotSpeed = Random.Range(insectParams.insectRotSpeed.min, insectParams.insectRotSpeed.max);

            if (isBadInsect)
            {
                Vector2 targetDir = ((Vector2)cakePoint.position - (Vector2)spawnPos).normalized;
                float angle = targetDir.x < 0 ? Vector2.Angle(targetDir, Vector2.up) : -Vector2.Angle(targetDir, Vector2.up);
                Quaternion rot = Quaternion.Euler(0, 0, angle);
                newInsect = InsectPool.InstantiateGameObjectByName(insectName, spawnPos, rot);

                BadInsect badInsectComponent = newInsect.GetComponent<BadInsect>();
                badInsectComponent.Initialize(cakePoint.position, randomSpeed / 10f, 
                    randomRotSpeed, insectParams.randomnessOfDirection);
            }
            else
            {
                Collider2D[] targetColliders = newSpawnPoint.targetCollider;

                Vector2 targetPos = targetColliders[0].gameObject.transform.position;
                Vector2 targetDir = (targetPos - (Vector2)spawnPos).normalized;
                float angle = targetDir.x < 0 ? Vector2.Angle(targetDir, Vector2.up) : -Vector2.Angle(targetDir, Vector2.up);
                Quaternion rot = Quaternion.Euler(0, 0, angle);

                newInsect = InsectPool.InstantiateGameObjectByName(insectName, spawnPos, rot);

                GoodInsect goodInsectComponent = newInsect.GetComponent<GoodInsect>();
                goodInsectComponent.Initialize(targetColliders, randomSpeed / 10f,
                    randomRotSpeed, insectParams.randomnessOfDirection);
            }

            _existedInsects.Add(newInsect);

            float randomTime = Random.Range(insectParams.timeBetweenSpawn.min, insectParams.timeBetweenSpawn.max);
            yield return new WaitForSeconds(randomTime);
        }
    }

    float AngleOf(Vector2 p1, Vector2 p2)
    {
        float deltaY = (p1.y - p2.y);
        float deltaX = (p2.x - p1.x);
        float result = ((float)System.Math.Atan2(deltaY, deltaX)) * 180f / (2f * (float) System.Math.PI);
        return result;
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
