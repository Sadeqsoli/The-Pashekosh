using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

#region Creating ItemPool Struct
[System.Serializable]
struct PoolStruc
{
    public string nameOfPool;
    public int initialSizeOfPool;
    public GameObject poolGameObject;
}
#endregion

public class InsectPool : MonoBehaviour
{
    #region private Fields
    [FormerlySerializedAs("_pools")] [SerializeField] PoolStruc[] pools;

    private static PoolStruc[] _pools;
    private static Dictionary<string, List<GameObject>> _poolsContent;
    private static Dictionary<string, GameObject> _parents;
    
    private GameObject newGameObject;
    private GameObject parent;
    #endregion

    #region private Methods

    private void Start()
    {
        InitializePoolsOnStart();
    }

    void InitializePoolsOnStart()
    {
        for (int i=0; i < pools.Length; i++)
        {
            pools[i].poolGameObject.name = pools[i].nameOfPool;
        }

        // ############# initialize ######################
        _pools = pools;
        _poolsContent = new Dictionary<string, List<GameObject>>();
        _parents = new Dictionary<string, GameObject>();
        // ################################################

        for (int i = 0; i < _pools.Length; i++)
        {
            string nameOfPool = _pools[i].nameOfPool;
            parent = new GameObject(_pools[i].nameOfPool);
            parent.transform.SetParent(this.transform);
            _parents.Add(nameOfPool, parent);
            _poolsContent.Add(nameOfPool, new List<GameObject>());
            StartCoroutine(InstantiatePoolsContent
                (_pools[i], parent.transform));
        }
    }

    IEnumerator InstantiatePoolsContent(PoolStruc pool, Transform poolParent)
    {

        for (int j = 0; j < pool.initialSizeOfPool; j++)
        {
            newGameObject =
                Instantiate(pool.poolGameObject, poolParent, true);
            newGameObject.name = pool.nameOfPool;
            newGameObject.SetActive(false);
            _poolsContent[pool.nameOfPool].Add(newGameObject);

            yield return new WaitForEndOfFrame();
        }
    }

    #endregion

    #region public Methods

    public static GameObject InstantiateGameObjectByName
        (string nameOfObject, Vector3 pos, Quaternion rotation)
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
                returnGameObject.transform.rotation = rotation;
                returnGameObject.transform.SetParent(_parents[nameOfObject].transform);
                return returnGameObject;
            }
            else
            {
                for(int i = 0; i < _pools.Length; i++)
                {
                    if (_pools[i].nameOfPool == nameOfObject)
                    {
                        var returnGameObject =
                            Instantiate(_pools[i].poolGameObject, pos, rotation);
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
