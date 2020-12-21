using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    #region Fields

    public List<string> impactsNames;
    #endregion

    #region Propertie
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Methods

    private void MakeImpact()
    {
        if (impactsNames.Count > 0)
        {
            var randIndex = Random.Range(0, impactsNames.Count);
            
            ItemPool.InstantiateGameObjectByName(impactsNames[randIndex], transform.position, quaternion.identity);
        }
    }
    #endregion
}
