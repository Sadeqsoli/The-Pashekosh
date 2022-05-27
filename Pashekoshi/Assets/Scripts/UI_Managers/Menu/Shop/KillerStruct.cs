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
    [SerializeField] GameObject[] SelectIcons;

    const int TAXCOINonKILLERS = 1000;

    void OnEnable()
    {
        UpdateTargetState();
    }

    void UpdateTargetState()
    {
        int killers = Killers.Length;
        for (int i = 0; i < killers; i++)
        {
            int currentTargetNumb = i;

            int taxForOpeningNewTarget = (currentTargetNumb + 1) * TAXCOINonKILLERS;

            if(WeaponRepo.Get() == (WeaponType)currentTargetNumb)
            {
                SelectIcons[i].SetActive(true);
            }
            else
            {
                SelectIcons[i].SetActive(false);
            }

            Locker locker = Killers[currentTargetNumb].gameObject.GetComponentInChildren<Locker>();
            bool isOpened;
            if (currentTargetNumb == 0)
            {
                isOpened = true;
            }
            else
            {
                isOpened = LockRepo.IsOpened(DB.Key((WeaponType)currentTargetNumb));
            }


            locker?.IsLocked(isOpened);
            if (!isOpened)
            {

                locker.SetDisplayFee(taxForOpeningNewTarget.ToString());
                locker.ChangeListener(delegate
                {
                    OpenNewWeapon(taxForOpeningNewTarget, (WeaponType)currentTargetNumb);
                });
            }
            Killers[currentTargetNumb].ChangeListener(delegate
            {
                SelectNewTarget((WeaponType)currentTargetNumb);
            });
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
            //Toast.Instance.SendToast("You need more coin!");
        }
    }

    void SelectNewTarget(WeaponType killerType)
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.Notif);
        WeaponRepo.Push(killerType);
        TrExt.SetObj_On(SelectIcons, (int)killerType);
    }



}//EndClassss
