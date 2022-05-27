using RTLTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GO_Shop : MonoBehaviour
{
    // shopButtons[0] = targetshop, shopButtons[1] = killershop, shopButtons[2] = powerupsShop
    [SerializeField] Sprite selectedSprite, deselectedSprite;
    [Space]
    [SerializeField] Button[] shopButtons;
    [Space]
    [SerializeField] GameObject[] shops;
    [Space]
    [SerializeField] Button NextButton;
    [Space]
    [SerializeField] Button ReplayButtonInShop;

    int currentShop = -1;

    void Start()
    {
        currentShop = -1;
        AddCategoryButtons();
        GoToNextShop();
    }//Starttttt

    void AddCategoryButtons()
    {
        ReplayButtonInShop.ChangeListener(GetBackToGamePlay);
        NextButton.ChangeListener(GoToNextShop);
        shopButtons[0].ChangeListener(ChangeToPowerupsShop);
        shopButtons[1].ChangeListener(ChangeToKillerShop);
        shopButtons[2].ChangeListener(ChangeToTargetShop);
    }
    void GetBackToGamePlay()
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        SceneController.Instance.GoToNextOrPrevScene(false, true);
    }

    void GoToNextShop()
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        currentShop++;
        if (currentShop >= 3)
        {
            //SceneController.Instance.GoToNextOrPrevScene(false, true);
            //return;
            currentShop = 0;
        }
        ChangeShopShelf(currentShop);
    }


    void ChangeShopShelf(int shopNumb)


    {
        switch (shopNumb)
        {
            case 0:
                ChangeToPowerupsShop();
                break;
            case 1:
                ChangeToKillerShop();
                break;
            case 2:
                ChangeToTargetShop();
                break;
        }
    }
    //when powerUps Shop is selected.
    void ChangeToPowerupsShop()
    {
        currentShop = 0;
        TrExt.SetObj_On(shops, 0);
        ChangeColor(shopButtons, 0);
    }
    //when Killer Shop is selected.
    void ChangeToKillerShop()
    {
        currentShop = 1;
        TrExt.SetObj_On(shops, 1);
        ChangeColor(shopButtons, 1);
    }
    //when Target Shop is selected.
    void ChangeToTargetShop()
    {
        currentShop = 2;
        TrExt.SetObj_On(shops, 2);
        ChangeColor(shopButtons, 2);
    }


    void ChangeColor(Button[] buttons, int numb)
    {
        int buttonsLength = buttons.Length;
        for (int i = 0; i < buttonsLength; i++)
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


}//EndClassss
