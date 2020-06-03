using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WindowGoesOff : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private void Awake()
    {
        
        StartCoroutine(WelcomeGoOff());
    }//Startttttt
    


    IEnumerator WelcomeGoOff()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }

    


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
