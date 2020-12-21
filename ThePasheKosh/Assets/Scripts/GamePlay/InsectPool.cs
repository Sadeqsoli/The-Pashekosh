using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

#region Creating ItemPool Struct
[System.Serializable]
internal struct PoolStruc
{
    public string nameOfPool;
    public int initialSizeOfPool;
    public GameObject poolGameObject;
}

#endregion

public class InsectPool : MonoBehaviour
{
    #region private Fields
    [FormerlySerializedAs("_pools")] [SerializeField] List<PoolStruc> pools;

    private static List<PoolStruc> _pools;
    private static Dictionary<string, List<GameObject>> _poolsContent;
    private static Dictionary<string, GameObject> _parents;
    
    private GameObject newGameObject;
    private GameObject parent;

    private static bool _instantiateWaiting;

    #endregion

    #region private Methods

    private void Start()
    {
        InitializePoolsOnStart();
    }

    void InitializePoolsOnStart()
    {
        
        for (int i=0; i < pools.Count; i++)
        {
            pools[i].poolGameObject.name = pools[i].nameOfPool;
        }

        // ############# initialize ######################
        _pools = new List<PoolStruc>(pools);
        _poolsContent = new Dictionary<string, List<GameObject>>();
        _parents = new Dictionary<string, GameObject>();
        // ################################################
        
        StartCoroutine(CreateEachPool());

    }

    IEnumerator CreateEachPool()
    {
        for (int i = 0; i < _pools.Count; i++)
        {
            _instantiateWaiting = false;
            
            string nameOfPool = _pools[i].nameOfPool;
            parent = new GameObject(_pools[i].nameOfPool);
            parent.transform.SetParent(this.transform);
            
            _parents.Add(nameOfPool, parent);

            _poolsContent.Add(nameOfPool, new List<GameObject>());
            StartCoroutine(InstantiatePoolsContent
                (_pools[i], parent.transform));
            
            _instantiateWaiting = true;

            yield return new WaitUntil(() => !_instantiateWaiting);
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

        _instantiateWaiting = false;
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
                _poolsContent[nameOfObject].RemoveAt(poolCurrentSize - 1);

                returnGameObject.SetActive(true);
                returnGameObject.transform.position = pos;
                returnGameObject.transform.rotation = rotation;
                returnGameObject.transform.SetParent(_parents[nameOfObject].transform);
                return returnGameObject;
            }
            else
            {
                for(int i = 0; i < _pools.Count; i++)
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

        return null;
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
