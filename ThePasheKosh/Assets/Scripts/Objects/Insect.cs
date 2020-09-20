using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    #region variables
    public enum InsectState { TowardsCake, OnCake, Stop}

    public bool isBadInsect;
    public Animation killedAnimation;
    public int addedPoints;
    public int impactRate;

    Vector2 _endPoint;
    Vector2 _spawnPoint;

    Quaternion _direction;


    Animator animatorComponent;

    Collider2D[] targetsCollider;
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
    public void RemoveInsect()
    {
        EventManager.StopListening("TouchCollider", KillHandling);
        Pool.DestroyGameObjectByName(this.name, this.gameObject);
    }

    public void Initialize(Vector2 endPoint, Collider2D[] targetsCollider, float speedOfInsect, float rotationSpeed, float randomDirectionPercent)
    {
        _spawnPoint = transform.position;
        _endPoint = endPoint;
        _speed = speedOfInsect;
        _rotationSpeed = rotationSpeed;
        _isInitialized = true;
        _randomDirectionPercent = randomDirectionPercent;

        this.targetsCollider = targetsCollider;

        CurrentState = InsectState.TowardsCake;
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
            case InsectState.TowardsCake:
                Move(0.1f);
                break;
            case InsectState.OnCake:
                Move(0.3f);
                break;
            case InsectState.Stop:
                break;
        }

        if (cakeCollider != null && !cakeCollider.IsTouching(colliderComponent))
        {
            cakeCollider = null;
            if (CurrentState == InsectState.OnCake) GoToFlyState();
        }

        if (!isBadInsect)
        {
            CheckReachingEndPoint();
        }

    }

    #region ChangeState

    public void GoToWalkState()
    {
        if (animatorComponent != null)
        {
            animatorComponent.SetBool("OnCake", true);
        }
        _speed /= 10;
        _rotationSpeed *= 2f;
        CurrentState = InsectState.OnCake;
    }
    
    public void GoToFlyState()
    {
        
        if (animatorComponent != null)
        {
            animatorComponent.SetBool("OnCake", false);
        }
        if (CurrentState == InsectState.OnCake)
        {
            _speed *= 10;
            _rotationSpeed /= 2f;
        }
        CurrentState = InsectState.TowardsCake;
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

    void CheckReachingEndPoint()
    {
        Vector2 pos = transform.position;
        if (Mathf.Abs(pos.x - _endPoint.x) < 0.2f && Mathf.Abs(pos.y - _endPoint.y) < 0.2f)
        {
            RemoveInsect();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isBadInsect && targetsCollider != null)
        {
            for (int i = 0; i < targetsCollider.Length; i++)
            {
                if (other == targetsCollider[i])
                {

                    InsectManager.Instance.RemoveInsect(this.gameObject);
                    RemoveInsect();
                }
            }
        }
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
