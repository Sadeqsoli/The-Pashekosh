using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class FoodManager : Singleton<FoodManager>
{
    public Transform screenCenterPoint;
    
    private FoodInfo currentFoodInfo;
    private Food currentFood;

    public void MakeFoodReady(FoodInfo foodInfo)
    {
        currentFoodInfo = foodInfo;
        currentFood = foodInfo.foodPrefab.GetComponent<Food>();
        
        DisplayFood(foodInfo);
        
        EventManager.StartListening(Events.FoodDestruction, FoodDestructionHandling);
        
        StartCoroutine(HealthUpdateCo());
    }

    private IEnumerator HealthUpdateCo()
    {
        var lastHealth = currentFood.Health;
        GameManager.Instance.UpdateHealth(currentFood.Health, currentFood.maxHealth);
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (Math.Abs(lastHealth - currentFood.Health) > 0.001f)
            {
                lastHealth = currentFood.Health;
                GameManager.Instance.UpdateHealth(currentFood.Health, currentFood.maxHealth);
            }
        }
    }

    private void FoodDestructionHandling()
    {
        Destroy(currentFood);
        //EventManager.TriggerEvent(Events.GameOver);
    }

    private void DisplayFood(FoodInfo foodInfo)
    {
        var foodGo =
            Instantiate(foodInfo.foodPrefab, screenCenterPoint.position, Quaternion.identity);
        
        currentFood = foodGo.GetComponent<Food>();
        
        currentFood.Initialize(foodInfo.foodSprites);
    }

    protected override void Awake()
    {
        base.Awake();
        
        /*gameObjectOfOnePiece.SetActive(false);
        for (int i = 0; i < gameObjectOfTwoPieces.Length; i++) gameObjectOfTwoPieces[i].SetActive(false);
        for (int i = 0; i < gameObjectOfFourPieces.Length; i++) gameObjectOfFourPieces[i].SetActive(false);
        */
    }

    private void Start()
    {
    }
}
