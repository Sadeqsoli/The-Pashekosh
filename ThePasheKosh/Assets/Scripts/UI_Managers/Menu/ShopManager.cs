using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // shopButtons[0] = targetshop, shopButtons[1] = killershop, shopButtons[2] = powerupsShop
    [SerializeField] Button[] shopButtons;
    [Space]
    [SerializeField] Sprite selectedSprite, deselectedSprite;
    [Space]
    [SerializeField] GameObject[] shops;

    void Start()
    {
        shopButtons[0].onClick.AddListener(ChangeToTargetShop);
        shopButtons[1].onClick.AddListener(ChangeToKillerShop);
        shopButtons[2].onClick.AddListener(ChangeToPowerupsShop);
        ChangeToKillerShop();
    }//Starttttt

    //when Target Shop is selected.
    void ChangeToTargetShop()
    {
        SetObj_On(shops, 0);
        ChangeColor(shopButtons, 0);
    }
    //when Killer Shop is selected.
    void ChangeToKillerShop()
    {
        SetObj_On(shops, 1);
        ChangeColor(shopButtons, 1);
    }
    //when powerUps Shop is selected.
    void ChangeToPowerupsShop()
    {
        SetObj_On(shops, 2);
        ChangeColor(shopButtons, 2);
    }

    //this used to change button sprite to selected.


    void ChangeListener(Button button, UnityAction unityAction)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(unityAction);
    }
    void ChangeColor(Button[] buttons, int numb)//changing the transform of suggestted button to mainHolder 
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (numb == i)
            {
                buttons[i].gameObject.GetComponent<Image>().sprite = selectedSprite;
            }
            else
            {
                buttons[i].gameObject.GetComponent<Image>().sprite = deselectedSprite;
            }
        }
    }
    void SetObj_On(GameObject[] gameObjects, int numb)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (numb == i)
            {
                gameObjects[i].SetActive(true);
            }
            else
            {
                gameObjects[i].SetActive(false);
            }
        }
    }


}//End Class
