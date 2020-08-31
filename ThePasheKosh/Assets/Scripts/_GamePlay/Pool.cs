﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Creating Pool Struct
[System.Serializable]
struct PoolStruc
{
    public string nameOfPool;
    public int InitialSizeOfPool;
    public GameObject poolGameObject;
}
#endregion

public class Pool : MonoBehaviour
{
    #region private Fields
    [SerializeField] PoolStruc[] _pools;

    static PoolStruc[] pools;
    static Dictionary<string, List<GameObject>> _poolsContent;
    static Dictionary<string, GameObject> _parents;
    GameObject _newGameObject;
    GameObject _parent;
    #endregion

    #region private Methods

    private void Start()
    {
        InitializePoolsOnStart();
    }

    void InitializePoolsOnStart()
    {
        for (int i=0; i < _pools.Length; i++)
        {
            _pools[i].poolGameObject.name = _pools[i].nameOfPool;
        }

        // ############# initialize ######################
        pools = _pools;
        _poolsContent = new Dictionary<string, List<GameObject>>();
        _parents = new Dictionary<string, GameObject>();
        // ################################################

        for (int i = 0; i < pools.Length; i++)
        {
            string nameOfPool = pools[i].nameOfPool;
            _parent = new GameObject(pools[i].nameOfPool);
            _parent.transform.SetParent(this.transform);
            _parents.Add(nameOfPool, _parent);
            _poolsContent.Add(nameOfPool, new List<GameObject>());
            StartCoroutine(InstantiatePoolsContent
                (pools[i], _parent.transform));
        }
    }

    IEnumerator InstantiatePoolsContent(PoolStruc pool, Transform parent)
    {

        for (int j = 0; j < pool.InitialSizeOfPool; j++)
        {
            _newGameObject =
                Instantiate(pool.poolGameObject) as GameObject;
            _newGameObject.name = pool.nameOfPool;
            _newGameObject.transform.SetParent(parent);
            _newGameObject.SetActive(false);
            _poolsContent[pool.nameOfPool].Add(_newGameObject);

            yield return new WaitForEndOfFrame();
        }
    }

    #endregion

    #region public Methods

    public static GameObject InstantiateGameObjectByName
        (string nameOfObject, Vector3 pos, Quaternion quaternion)
    {
        if (_poolsContent.ContainsKey(nameOfObject))
        {
            var poolCurrentSize = _poolsContent[nameOfObject].Count;
            if (poolCurrentSize > 0)
            {
                var returnGameObject = _poolsContent[nameOfObject][poolCurrentSize - 1];
                _poolsContent[nameOfObject].Remove(returnGameObject);

                returnGameObject.SetActive(true);
                returnGameObject.transform.position = pos;
                returnGameObject.transform.SetParent(_parents[nameOfObject].transform);
                return returnGameObject;
            }
            else
            {
                for(int i = 0; i < pools.Length; i++)
                {
                    if (pools[i].nameOfPool == nameOfObject)
                    {
                        var returnGameObject =
                            Instantiate(pools[i].poolGameObject, pos, quaternion);
                        returnGameObject.name = nameOfObject;
                        returnGameObject.transform.SetParent(_parents[nameOfObject].transform);
                        return returnGameObject;
                    }
                }
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public static void DestroyGameObjectByName(string name, GameObject destroyedGameObject)
    {
        if (_poolsContent.ContainsKey(name))
        {
            destroyedGameObject.SetActive(false);
            _poolsContent[name].Add(destroyedGameObject);
        }
        else
        {
            Debug.LogError("The name doesn't exist in the pool list.");
        }
    }

    #endregion
}
