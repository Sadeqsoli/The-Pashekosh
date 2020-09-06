using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    #region variables
    public enum InsectState { Fly, Walk, Stop}

    public bool isBadInsect;
    public Animation killedAnimation;
    public int addedPoints;
    public int impactRate;

    Vector2 _endPoint;
    Vector2 _spawnPoint;

    Quaternion _direction;


    Animator animatorComponent;

    Collider2D cakeCollider;
    Collider2D colliderComponent;
    
    float _speed;
    float _rotationSpeed;

    bool _isInitialized = false;

    float _randomDirectionPercent;

    #endregion

    #region Properties
    public InsectState CurrentState { get; private set; }

    public bool IsOnCake { get; private set; }
    #endregion

    #region Methods
    public void removeInsect()
    {
        EventManager.StopListening("TouchCollider", KillHandling);
        Pool.DestroyGameObjectByName(this.name, this.gameObject);
    }

    public void Initialize(Vector2 endPoint, float speedOfInsect, float rotationSpeed, float randomDirectionPercent)
    {
        _spawnPoint = transform.position;
        _endPoint = endPoint;
        _speed = speedOfInsect;
        _rotationSpeed = rotationSpeed;
        _isInitialized = true;
        _randomDirectionPercent = randomDirectionPercent;

        CurrentState = InsectState.Fly;
        GoToFlyState();

        animatorComponent = GetComponent<Animator>();
        colliderComponent = GetComponent<Collider2D>();

        EventManager.StartListening("TouchCollider", KillHandling);
    }

    public void SetCakeCollider(Collider2D cakeCollider)
    {
        this.cakeCollider = cakeCollider;
    }

    void Update()
    {
        switch (CurrentState)
        {
            case InsectState.Fly:
                Move(0.1f);
                break;
            case InsectState.Walk:
                Move(0.3f);
                break;
            case InsectState.Stop:

                break;
        }

        if (cakeCollider != null && !cakeCollider.IsTouching(colliderComponent))
        {
            cakeCollider = null;
            if (CurrentState == InsectState.Walk) GoToFlyState();
        }
    }

    #region ChangeState

    public void GoToWalkState()
    {
        if (animatorComponent != null)
        {
            animatorComponent.SetBool("Walk", true);
        }
        _speed /= 10;
        _rotationSpeed *= 2f;
        CurrentState = InsectState.Walk;
    }
    
    public void GoToFlyState()
    {
        
        if (animatorComponent != null)
        {
            animatorComponent.SetBool("Walk", false);
        }
        if (CurrentState == InsectState.Walk)
        {
            _speed *= 10;
            _rotationSpeed /= 2f;
        }
        CurrentState = InsectState.Fly;
    }
    #endregion

    #region Moving Methods

    void Move(float ChangeDirectionPercentage)
    {
        if (_isInitialized)
        {
            if (Random.value < ChangeDirectionPercentage)
            {
                ChangeDirection();
            }
            Rotate();
            GoDirect();
        }
    }
    void GoDirect()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
    void ChangeDirection()
    {
        Vector2 targetDir = (_endPoint - (Vector2)transform.position).normalized;
        Vector2 randomDir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        Vector2 mean = (((1 - _randomDirectionPercent) * targetDir + (_randomDirectionPercent) * randomDir));
        float angle = mean.x < 0 ? Vector2.Angle(mean, Vector2.up) : -Vector2.Angle(mean, Vector2.up);
        _direction = Quaternion.Euler(0, 0, angle);
    }
    void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _direction, _rotationSpeed * Time.deltaTime);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
    }

    private void OnEnable()
    {
        _isInitialized = false;
    }
    private void OnDisable()
    {
        _isInitialized = false;
        CurrentState = InsectState.Stop;
    }

    #endregion
}
