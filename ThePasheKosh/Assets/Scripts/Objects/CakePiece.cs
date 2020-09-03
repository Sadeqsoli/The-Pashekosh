using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePiece : MonoBehaviour
{
    float damage = 0;

    Coroutine updateHealthCoroutine;

    bool isCoroutineRunning = false;

    public float Health { get; private set; }

    float Damage{
        get 
        {
            return damage;
        }
        set
        {
            if (value < 20)
            {
                damage = value;
            }
            else damage = 20;
        }
    }

    public void AddDamage(float quantity)
    {
        Damage += quantity;
    }
    
    public void InitializeCake()
    {
        updateHealthCoroutine = StartCoroutine(UpdateHealthCoroutine());
    }

    public void RemoveCake()
    {
        if (isCoroutineRunning) StopCoroutine(updateHealthCoroutine);
        this.gameObject.SetActive(false);
    }

    void AddHealth(float quantity)
    {
        Health += quantity;
        if (Health <= 0) Health = 0;
        else if (Health >= 100) Health = 100;
    }

    IEnumerator UpdateHealthCoroutine()
    {
        isCoroutineRunning = true;
        while (Health > 0)
        {
            yield return new WaitForSeconds(0.1f);
            AddHealth(-damage);
        }
        isCoroutineRunning = false;

        EventManager.TriggerEvent("CakePieceDestroyed", this.gameObject);
        RemoveCake();
    }

}
