using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour
{

    // the image you want to fade, assign in inspector
    [SerializeField] Image img;

    public void CallEvents()
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(int numb, int Seq_CharOn)
    {
        //Do whatever that you want befor
        img.gameObject.SetActive(true);
        // fade from transparent to opaque
        // loop over 1 second
        for (float j = 0; j <= 1; j += Time.deltaTime)
        {
            if (j > 0.1)
            {
                //TODO:  fadein begins
            }
            // set color with i as alpha
            img.color = new Color(1, 1, 1, j);
            yield return new WaitForSeconds(0.005f);
        }

        // fade from opaque to transparent
        // loop over 1 second backwards
        for (float j = 1; j >= 0; j -= Time.deltaTime)
        {
            if (j < 0.1)
            {
                //TODO: right before fadeout ends
            }
            // set color with i as alpha
            img.color = new Color(1, 1, 1, j);
            yield return new WaitForSeconds(0.005f);
        }
        img.gameObject.SetActive(false);
        //Do whatever that you want after
    }



    //raw code that do both ways
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }



}//EndClasssss/SadeQ
