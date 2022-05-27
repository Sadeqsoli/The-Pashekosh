using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetStruct : MonoBehaviour
{
    /// <summary>
    /// Targets[X] = ENume TargetManager.TargetType
    /// </summary>
    [SerializeField] Button[] Targets;
    [SerializeField] GameObject[] SelectIcons;


    const int TAXCOINonTARGETS = 1000;

    void OnEnable()
    {
        UpdateTargetState();
    }

    void UpdateTargetState()
    {
        int targets = Targets.Length;
        for (int i = 0; i < targets; i++)
        {
            int currentTargetNumb = i;

            int taxForOpeningNewTarget = (currentTargetNumb + 1) * TAXCOINonTARGETS;

            if (TargetRepo.Get() == (FoodType)currentTargetNumb)
            {
                SelectIcons[i].SetActive(true);
            }
            else
            {
                SelectIcons[i].SetActive(false);
            }

            Locker locker = Targets[currentTargetNumb].gameObject.GetComponentInChildren<Locker>();
            bool isOpened;
            if (currentTargetNumb == 0)
            {
                isOpened = true;
            }
            else
            {
                isOpened = LockRepo.IsOpened(DB.Key((FoodType)currentTargetNumb));
            }

            locker?.IsLocked(isOpened);
            if (!isOpened)
            {
                locker.SetDisplayFee(taxForOpeningNewTarget.ToString());
                locker.ChangeListener(delegate { OpenNewBackground(taxForOpeningNewTarget, (FoodType)currentTargetNumb); });
            }

            Targets[currentTargetNumb].onClick.AddListener(delegate { SetNewTarget((FoodType)currentTargetNumb); });
        }
    }

    void OpenNewBackground(int taxCoin, FoodType targetType)
    {
        if (CoinRepo.PopCoins(taxCoin))
        {
            SFXPlayer.Instance.PlaySFX(UIFeedback.BuyOrSelectItem);
            LockRepo.OpenLock(DB.Key(targetType),true);
            UpdateTargetState();
        }
        else
        {
            SFXPlayer.Instance.PlaySFX(UIFeedback.Locked);
            //TODO: Open Warning for watching Ad to get some coin!
            Debug.Log("You need more coin!");
        }
    }

    void SetNewTarget(FoodType targetType)
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.Notif);
        if (TargetManager.Instance.CurrentTarget != targetType)
            TargetManager.Instance.UpdateBackground(targetType);
        TargetRepo.Push(targetType);
        TrExt.SetObj_On(SelectIcons, (int)targetType);
    }



}//EndClassss
