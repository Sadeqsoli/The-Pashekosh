using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public struct InsectWithCollider
{
    public BadInsect insect;
    public Collider2D collider;
}
public class Cake : MonoBehaviour
{
    public float maxHealth = 100f;
    
    private Coroutine updateHealthCoroutine;

    private List<InsectWithCollider> badInsectsWithColliders;

    private Collider2D cakeCollider;

    private SpriteRenderer spriteRenderer;

    private float damage;

    private bool isCoroutineRunning;
    private bool isInitialized;

    private List<Sprite> cakeSprites;

    [field: SerializeField]
    public float Health { get; private set; }

    private float Damage{
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
    
    public void InitializeCake(List<Sprite> currentCakeSprites)
    {
        cakeSprites = currentCakeSprites;

        damage = 0;

        Health = maxHealth;

        isInitialized = true;

        badInsectsWithColliders = new List<InsectWithCollider>();

        cakeCollider = GetComponent<Collider2D>();

        updateHealthCoroutine = StartCoroutine(UpdateHealthCoroutine());

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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

                    UpdateSprite();
                }
            }
        }
    }

    private void UpdateSprite()
    {
        var losingHealth = maxHealth - Health;
        var part = maxHealth / cakeSprites.Count;

        var currentSprite = cakeSprites[(int) (losingHealth / part)];

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
        }
        isCoroutineRunning = false;

        EventManager.TriggerEvent(Events.CakePieceDestroyed, this.gameObject);
        RemoveCake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) {
            BadInsect insectComponent = collision.gameObject.GetComponent<BadInsect>();

            if (insectComponent.CurrentState != BadInsectState.OnCake && Random.value > 0.3f)
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

    private void OnDisable()
    {
        damage = 0;
        isInitialized = false;
    }

}
