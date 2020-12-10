using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Insect : MonoBehaviour
{
    #region variables


    public GameObject insectDead;

    private Vector2 endPoint;
    private Vector2 spawnPoint;

    private Quaternion direction;

    protected Animator animatorComponent;

    protected Collider2D[] targetsCollider;
    protected Collider2D foodCollider;
    protected Collider2D colliderComponent;

    protected Rigidbody2D rigidBody2d;

    protected float speed;
    protected float rotationSpeed;

    private bool isInitialized;

    private float randomDirectionPercent;

    private Coroutine changeDirectionCo;

    #endregion

    #region Properties
    
    public bool IsBadInsect { get; protected set; }
    #endregion

    #region Methods
    public void RemoveInsect()
    {
        EventManager.StopListening(Events.TouchCollider, KillHandling);
        InsectPool.DestroyGameObjectByName(this.name, this.gameObject);
    }

    public virtual void Initialize(Vector2 end, Collider2D[] targets, float speedOfInsect, float rotSpeed, float randDirectionPercent)
    {
        spawnPoint = transform.position;
        endPoint = end;
        speed = speedOfInsect;
        rotationSpeed = rotSpeed;
        isInitialized = true;
        randomDirectionPercent = randDirectionPercent;

        targetsCollider = targets;

        animatorComponent = GetComponent<Animator>();
        colliderComponent = GetComponent<Collider2D>();

        EventManager.StartListening(Events.TouchCollider, KillHandling);
    }

    public void SetFoodCollider(Collider2D food)
    {
        foodCollider = food;
    }

    protected virtual void Update()
    {
        
    }

    #region Moving Methods

    protected void Move()
    {
        if (!isInitialized) return;
        Rotate();
        GoDirect();
    }
    
    void GoDirect()
    {
        //transform.Translate(Vector2.up * _speed * Time.deltaTime);
        rigidBody2d.velocity = new Vector2(0, 0);
        rigidBody2d.AddRelativeForce(Vector2.up * speed * Time.deltaTime * 10, ForceMode2D.Impulse);
    }

    protected void ChangeDirection(float randomness)
    {
        Vector2 targetDir = (endPoint - (Vector2)transform.position).normalized;
        Vector2 randomDir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        Vector2 mean = (((1 - randomness) * targetDir + (randomness) * randomDir));
        float angle = mean.x < 0 ? Vector2.Angle(mean, Vector2.up) : -Vector2.Angle(mean, Vector2.up);
        direction = Quaternion.Euler(0, 0, angle);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, rotationSpeed * Time.deltaTime);
    }

    protected virtual IEnumerator ChangeDirectionCo()
    {
        float counter = 0;
        while (true)
        {
            float randomness = FProb(counter, 6f, 3f);
            ChangeDirection(randomness);
            yield return new WaitForSeconds(1f);
            counter += 1f;
        }
    }

    #endregion

    void KillHandling(GameObject insect)
    {
        if (insect == gameObject)
        {
            EventManager.TriggerEvent(Events.InsectKilled, gameObject);

            EventManager.StopListening(Events.TouchCollider, KillHandling);

            InsectPool.InstantiateGameObjectByName(name + "_Dead", transform.position, transform.rotation);

            InsectPool.DestroyGameObjectByName(name, gameObject);
        }
    }

    private void OnEnable()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        isInitialized = false;
        changeDirectionCo = StartCoroutine(ChangeDirectionCo());
    }
    protected virtual void OnDisable()
    {
        isInitialized = false;
        StopCoroutine(changeDirectionCo);
    }

    #endregion

    protected static float FProb(float x, float mean, float stddev)
    {
        var exp1 = (1f / stddev);// * 0.398942f;
        var exp2D = System.Math.Exp(-(x - mean) * (x - mean) / (2 * stddev * stddev));
        var exp2 = (float)exp2D;
        return exp1 * exp2;
    }
}
