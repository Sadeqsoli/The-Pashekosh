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


    const int TAXCOINonTARGETS = 1000;

    void OnEnable()
    {
        UpdateTargetState();
    }

    void UpdateTargetState()
    {
        for (int i = 1; i < Targets.Length; i++)
        {
            int currentTargetNumb = i;

            int taxForOpeningNewTarget = (currentTargetNumb + 1) * TAXCOINonTARGETS;

            Locker locker = Targets[currentTargetNumb].gameObject.GetComponentInChildren<Locker>();

            bool isOpened = LockRepo.IsOpened(DB.Key((FoodType)currentTargetNumb));

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
            //TODO: Make a sound for opening 
            //TODO: Make a Visual for opening 
            LockRepo.OpenLock(DB.Key(targetType),true);
            UpdateTargetState();
        }
        else
        {
            //TODO: Make a sound for being locked. 
            //TODO: Make a Visual for being locked. 
            //TODO: Open Warning for watching Ad to get some coin!
            Debug.Log("You need more coin!");
        }
    }

    void SetNewTarget(FoodType targetType)
    {
        if (TargetManager.Instance.CurrentTarget != targetType)
            TargetManager.Instance.UpdateBackground(targetType);
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

}//EndClassss
