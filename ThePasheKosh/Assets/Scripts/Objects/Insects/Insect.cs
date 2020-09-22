using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    #region variables

    public bool isBadInsect;
    public Animation killedAnimation;

    protected Vector2 _endPoint;
    protected Vector2 _spawnPoint;

    protected Quaternion _direction;

    protected Animator animatorComponent;

    protected Collider2D[] targetsCollider;
    protected Collider2D cakeCollider;
    protected Collider2D colliderComponent;

    protected Rigidbody2D rigidBody2d;

    protected float _speed;
    protected float _rotationSpeed;

    protected bool _isInitialized = false;

    protected float _randomDirectionPercent;

    Coroutine changeDirectionCo;

    #endregion

    #region Properties

    #endregion

    #region Methods
    public void RemoveInsect()
    {
        EventManager.StopListening("TouchCollider", KillHandling);
        Pool.DestroyGameObjectByName(this.name, this.gameObject);
    }

    public virtual void Initialize(Vector2 endPoint, Collider2D[] targetsCollider, float speedOfInsect, float rotationSpeed, float randomDirectionPercent)
    {
        _spawnPoint = transform.position;
        _endPoint = endPoint;
        _speed = speedOfInsect;
        _rotationSpeed = rotationSpeed;
        _isInitialized = true;
        _randomDirectionPercent = randomDirectionPercent;

        this.targetsCollider = targetsCollider;

        animatorComponent = GetComponent<Animator>();
        colliderComponent = GetComponent<Collider2D>();

        EventManager.StartListening("TouchCollider", KillHandling);
    }

    public void SetCakeCollider(Collider2D cakeCollider)
    {
        this.cakeCollider = cakeCollider;
    }

    protected virtual void Update()
    {
        
    }

    #region Moving Methods

    protected void Move()
    {
        if (_isInitialized)
        {
            Rotate();
            GoDirect();
        }
    }
    void GoDirect()
    {
        //transform.Translate(Vector2.up * _speed * Time.deltaTime);
        rigidBody2d.velocity = new Vector2(0, 0);
        rigidBody2d.AddRelativeForce(Vector2.up * _speed * Time.deltaTime * 10, ForceMode2D.Impulse);
    }

    protected void ChangeDirection(float randomness)
    {
        Vector2 targetDir = (_endPoint - (Vector2)transform.position).normalized;
        Vector2 randomDir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        Vector2 mean = (((1 - randomness) * targetDir + (randomness) * randomDir));
        float angle = mean.x < 0 ? Vector2.Angle(mean, Vector2.up) : -Vector2.Angle(mean, Vector2.up);
        _direction = Quaternion.Euler(0, 0, angle);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _direction, _rotationSpeed * Time.deltaTime);
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
        if (insect == this.gameObject)
        {
            EventManager.TriggerEvent("InsectKilled", this.gameObject);

            EventManager.StopListening("TouchCollider", KillHandling);

            Pool.DestroyGameObjectByName(this.name, this.gameObject);
        }
    }

    private void OnEnable()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        _isInitialized = false;
        changeDirectionCo = StartCoroutine(ChangeDirectionCo());
    }
    protected virtual void OnDisable()
    {
        _isInitialized = false;
        StopCoroutine(changeDirectionCo);
    }

    #endregion

    protected float FProb(float x, float mean, float stddev)
    {
        float exp1 = (1f / stddev);// * 0.398942f;
        double exp2_d = System.Math.Exp(-(x - mean) * (x - mean) / (2 * stddev * stddev));
        float exp2 = (float)exp2_d;
        return exp1 * exp2;
    }
}
