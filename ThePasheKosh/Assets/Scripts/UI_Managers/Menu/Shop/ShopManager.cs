using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // shopButtons[0] = targetshop, shopButtons[1] = killershop, shopButtons[2] = powerupsShop
    [SerializeField] Sprite selectedSprite, deselectedSprite;
    [Space]
    [SerializeField] Button[] shopButtons;
    [Space]
    [SerializeField] GameObject[] shops;
    [Space]
    [SerializeField] Button ClosingShopButton;

    void Start()
    {
        AddCategoryButtons();
        ChangeToKillerShop();
    }//Starttttt

    void AddCategoryButtons()
    {
        ClosingShopButton.onClick.AddListener(GetBackToMain);
        shopButtons[0].onClick.AddListener(ChangeToTargetShop);
        shopButtons[1].onClick.AddListener(ChangeToKillerShop);
        shopButtons[2].onClick.AddListener(ChangeToPowerupsShop);
    }

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


    void GetBackToMain()
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        MainMenu.Instance.SetCoinsText();
        gameObject.transform.Scaler(TTScale.ScaleDown);
    }


    void ChangeListener(Button button, UnityAction unityAction)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(unityAction);
    }
    void ChangeColor(Button[] buttons, int numb)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (numb == i)
            {
                SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
                buttons[i].gameObject.GetComponent<Image>().sprite = selectedSprite;
                buttons[i].gameObject.GetComponentInChildren<RTLTextMeshPro>()
                    .TXTColoring(TTTColoring.SimpleColoring, Color.black);
            }
            else
            {
                buttons[i].gameObject.GetComponent<Image>().sprite = deselectedSprite;
                buttons[i].gameObject.GetComponentInChildren<RTLTextMeshPro>()
                    .TXTColoring(TTTColoring.SimpleColoring, Color.white);
            }
        }
    }
    void SetObj_On(GameObject[] gameObjects, int numb)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (numb == i)
            {
                if (!gameObjects[i].activeSelf)
                {
                    gameObjects[i].transform.Scaler(TTScale.ScaleUp);
                    SFXPlayer.Instance.PlaySFX(UIFeedback.Open);
                }
            }
            else
            {
                if (gameObjects[i].activeSelf)
                    gameObjects[i].transform.Scaler(TTScale.ScaleDown, null, 0.5f);
            }
        }
    }


}//End Class
