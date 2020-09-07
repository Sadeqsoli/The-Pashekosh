using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct InsectWithCollider
{
    public Insect insect;
    public Collider2D collider;
}
public class CakePiece : MonoBehaviour
{
    Coroutine updateHealthCoroutine;

    List<InsectWithCollider> badInsectsWithColliders;

    Collider2D cakeCollider;

    public float damage;
    float maxHealth;

    bool isCoroutineRunning = false;
    bool isInitialized;

    [field: SerializeField]
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
    
    public void InitializeCake(float maxHealth)
    {

        damage = 0;

        this.maxHealth = maxHealth;

        Health = maxHealth;

        isInitialized = true;

        badInsectsWithColliders = new List<InsectWithCollider>();

        cakeCollider = GetComponent<Collider2D>();

        updateHealthCoroutine = StartCoroutine(UpdateHealthCoroutine());

    }

    public void RemoveCake()
    {
        damage = 0;

        isInitialized = false;

        if (isCoroutineRunning) StopCoroutine(updateHealthCoroutine);

        GetComponent<SpriteRenderer>().sprite = null;
    }

    void Update()
    {
        if (isInitialized)
        {
            for (int i = 0; i < badInsectsWithColliders.Count; i++)
            {
                if (!cakeCollider.IsTouching(badInsectsWithColliders[i].collider))
                {
                    AddDamage(-badInsectsWithColliders[i].insect.impactRate);
                    badInsectsWithColliders.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    void AddHealth(float quantity)
    {
        Health += quantity;
        if (Health <= 0) Health = 0;
        else if (Health >= maxHealth) Health = maxHealth;
    }

    IEnumerator UpdateHealthCoroutine()
    {
        isCoroutineRunning = true;
        while (Health > 0)
        {
            yield return new WaitForSeconds(0.5f);
            AddHealth(-damage);
        }
        isCoroutineRunning = false;

        EventManager.TriggerEvent("CakePieceDestroyed", this.gameObject);
        RemoveCake();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) {
            Insect insectComponent = collision.gameObject.GetComponent<Insect>();

            if (insectComponent.CurrentState != Insect.InsectState.OnCake && Random.value > 0.3f)
            {
                insectComponent.GoToWalkState();
                insectComponent.SetCakeCollider(GetComponent<Collider2D>());

                InsectWithCollider newInsectWithCollider;
                newInsectWithCollider.collider = collision;
                newInsectWithCollider.insect = insectComponent;

                if (!badInsectsWithColliders.Contains(newInsectWithCollider))
                {
                    badInsectsWithColliders.Add(newInsectWithCollider);
                    AddDamage(insectComponent.impactRate);
                }
            }
        }
    }

    void OnDisable()
    {
        damage = 0;
        isInitialized = false;
    }

}
