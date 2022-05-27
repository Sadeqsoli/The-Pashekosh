using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TypingFX : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    private string currentText = "";
    float delay = 0.1f;
    string fullText;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    void Start()
    {
        StartCoroutine(TypingEng());
    }//Starttttt


    IEnumerator TypingEng()
    {
        for (int i = 0; i < fullText.Length + 1; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
