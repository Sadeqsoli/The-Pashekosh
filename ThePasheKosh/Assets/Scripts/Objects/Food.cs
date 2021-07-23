using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


[System.Serializable]
public struct InsectWithCollider
{
    public BadInsect insect;
    public Collider2D collider;
}

public class Food : MonoBehaviour
{
    public float maxHealth = 100f;

    private Coroutine updateHealthCoroutine;

    [SerializeField] private List<InsectWithCollider> badInsectsWithColliders;

    [SerializeField] private Collider2D foodCollider;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private float damage;

    private bool isCoroutineRunning;
    private bool isInitialized;

    private List<Sprite> foodSprites;

    [field: SerializeField] 
    public float Health { get; private set; }

    #region Methods

    public void Initialize(List<Sprite> currentFoodSprites)
    {
        foodSprites = currentFoodSprites;

        damage = 0;

        Health = maxHealth;

        isInitialized = true;

        badInsectsWithColliders = new List<InsectWithCollider>();

        foodCollider = GetComponent<Collider2D>();

        updateHealthCoroutine = StartCoroutine(UpdateHealthCoroutine());

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        EventManager.StartListening(Events.TouchCollider, OnCakeHit);
        EventManager.StartListening(Events.ZeroHealth, RemoveFood);
    }

    private float Damage
    {
        get => damage;
        set
        {
            if (value < 20)
            {
                damage = value;
            }
            else damage = 20;
        }
    }

    private void AddDamage(float quantity)
    {
        Damage += quantity;
    }


    private void RemoveFood()
    {
        damage = 0;

        isInitialized = false;

        if (isCoroutineRunning) StopCoroutine(updateHealthCoroutine);

        GetComponent<SpriteRenderer>().sprite = null;
        
        EventManager.TriggerEvent(Events.FoodDestruction);
    }

    void Update()
    {
        if (isInitialized)
        {
            for (int i = 0; i < badInsectsWithColliders.Count; i++)
            {
                if (!foodCollider.IsTouching(badInsectsWithColliders[i].collider))
                {
                    AddDamage(-badInsectsWithColliders[i].insect.impactRate);
                    badInsectsWithColliders.RemoveAt(i);
                    i--;

                }
            }
        }
    }

    private void UpdateSprite()
    {
        var losingHealth = maxHealth - Health < maxHealth? maxHealth - Health : maxHealth - 1;
        var part = maxHealth / foodSprites.Count;
        
        var currentSprite = foodSprites[(int) (losingHealth / part)];

        if (spriteRenderer.sprite != currentSprite)
        {
            spriteRenderer.sprite = currentSprite;
        }
    }

    private void AddHealth(float quantity)
    {
        Health += quantity;
        if (Health <= 0) Health = 0;
        else if (Health >= maxHealth) Health = maxHealth;
    }

    private IEnumerator UpdateHealthCoroutine()
    {
        isCoroutineRunning = true;
        while (Health > 0)
        {
            yield return new WaitForSeconds(0.5f);
            AddHealth(-damage);
            
            UpdateSprite();
        }

        isCoroutineRunning = false;

        //RemoveFood();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            BadInsect insectComponent = collision.gameObject.GetComponent<BadInsect>();

            if (insectComponent.CurrentState != BadInsectState.OnFood)
            {
                insectComponent.GoToWalkState();
                insectComponent.SetFoodCollider(GetComponent<Collider2D>());
                
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

    private void OnDisable()
    {
        damage = 0;
        isInitialized = false;
    }

    private void OnCakeHit(GameObject hit)
    {
        if(hit == gameObject)
            Health -= maxHealth / 2;
    }

    #endregion
}