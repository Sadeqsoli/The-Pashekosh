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

    void Start()
    {
        UpdateTargetState();
    }

    void UpdateTargetState()
    {
        for (int i = 0; i < Killers.Length; i++)
        {
            int currentTargetNumb = i;

            int taxForOpeningNewTarget = (currentTargetNumb + 1) * TAXCOINonKILLERS;

            Locker locker = Killers[currentTargetNumb].gameObject.GetComponentInChildren<Locker>();

            bool isLocked = LockRepo.IsRepoHas(LockRepo.GetOpenedTarget());

            locker.gameObject.SetActive(isLocked);
            if (isLocked)
            {
                locker.SetDisplayFee(taxForOpeningNewTarget.ToString());
                locker.ChangeListener(delegate { OpenNewBackground(taxForOpeningNewTarget, (WeaponType)currentTargetNumb); });
            }

            Killers[currentTargetNumb].onClick.AddListener(delegate { SetNewTarget((WeaponType)currentTargetNumb); });
        }
    }
    
    void OpenNewBackground(int taxCoin, WeaponType weaponType)
    {
        if (CoinRepo.PopCoins(taxCoin))
        {
            //TODO: Make a sound for opening 
            //TODO: Make a Visual for opening 
            LockRepo.OpenTarget(DB.Key(weaponType.ToString()));
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
