using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillerStruct : MonoBehaviour
{
    /// <summary>
    /// Targets[X] = ENume TargetManager.TargetType
    /// </summary>
    [SerializeField] Button[] Killers;

    const int TAXCOINonKILLERS = 1000;

    void OnEnable()
    {
        UpdateTargetState();
    }

    void UpdateTargetState()
    {
        int kellerChildCount = Killers.Length;
        for (int i = 1; i < kellerChildCount; i++)
        {
            int currentTargetNumb = i;

            int taxForOpeningNewTarget = (currentTargetNumb + 1) * TAXCOINonKILLERS;

            Locker locker = Killers[currentTargetNumb].gameObject.GetComponentInChildren<Locker>();

            bool isOpened = LockRepo.IsOpened(DB.Key((WeaponType)currentTargetNumb));

            locker?.IsLocked(isOpened);
            if (!isOpened)
            {

                locker.SetDisplayFee(taxForOpeningNewTarget.ToString());
                locker.ChangeListener(delegate
                {
                    OpenNewWeapon(taxForOpeningNewTarget, (WeaponType)currentTargetNumb);
                });
            }
            else
            {
                Killers[currentTargetNumb].onClick.AddListener(delegate
                {
                    SetNewTarget((WeaponType)currentTargetNumb);
                });
            }
        }
    }

    void OpenNewWeapon(int taxCoin, WeaponType weaponType)
    {
        if (CoinRepo.PopCoins(taxCoin))
        {
            //TODO: Make a Visual for opening 
            SFXPlayer.Instance.PlaySFX(UIFeedback.BuyOrSelectItem);
            LockRepo.OpenLock(DB.Key(weaponType), true);
            UpdateTargetState();
        }
        else
        {
            //TODO: Open Warning for watching Ad to get some coin!
            SFXPlayer.Instance.PlaySFX(UIFeedback.Locked);
            Toast.Instance.SendToast("You need more coin!");
        }
    }

    void SetNewTarget(WeaponType killerType)
    {

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

}
