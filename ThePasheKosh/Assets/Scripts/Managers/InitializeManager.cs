using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitializeManager : MonoBehaviour
{
    #region Fields
    [SerializeField] bool isDatabaseInitialized = false;
    [SerializeField] bool isWriterReaderInitialized = false;
    [SerializeField] bool isNetCenterInitialized = false;


    #endregion

    #region Properties

    #endregion


    #region Methods
    private void Awake()
    {
        Initializer();
    }

    void Initializer()
    {
        if (isDatabaseInitialized)
        {
            DatabaseManager.Initialize();
        }

        if (isWriterReaderInitialized)
        {
            StreamUtility.InitWriterReader();
        }
        if (isNetCenterInitialized)
        {
            NetCenter.InitializeNetCenter();
        }
    }


    #endregion//Methods
}//EndClasssss/SadeQ
