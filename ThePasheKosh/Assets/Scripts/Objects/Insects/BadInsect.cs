using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public enum BadInsectState { TowardsFood, OnFood, Wind, Stop }


public class BadInsect : Insect
{
    public float windPower;
    
    public int addedPoints;
    public int impactRate;
    private static readonly int OnFood = Animator.StringToHash("OnFood");

    public bool IsOnFood { get; private set; }

    public BadInsectState CurrentState { get; private set; }

    protected override void Update()
    {
        base.Update();

        switch (CurrentState)
        {
            case BadInsectState.TowardsFood:
                Move();
                break;
            case BadInsectState.OnFood:
                rigidBody2d.velocity = new Vector2(0, 0);
                Move();
                break;
            case BadInsectState.Wind:
                MoveAgainstCake();
                break;
            case BadInsectState.Stop:
                break;
        }

        if (foodCollider != null && !foodCollider.IsTouching(colliderComponent))
        {
            foodCollider = null;
            if (CurrentState == BadInsectState.OnFood) GoToFlyState();
        }
    }

    public void Initialize(Vector2 endPoint, float insectSpeed, float rotSpeed, float randDirectionRatio)
    {
        CurrentState = BadInsectState.TowardsFood;
        GoToFlyState();

        Initialize(endPoint, null, insectSpeed, rotSpeed, randDirectionRatio);
        IsBadInsect = true;
    }

    #region ChangeState

    public void GoToWalkState()
    {
        if (animatorComponent != null)
        {
            animatorComponent.SetBool(OnFood, true);
        }
        speed /= 10;
        rotationSpeed *= 2f;
        CurrentState = BadInsectState.OnFood;
    }

    public void GoToFlyState()
    {

        if (animatorComponent != null)
        {
            animatorComponent.SetBool(OnFood, false);
        }
        if (CurrentState == BadInsectState.OnFood)
        {
            speed *= 10;
            rotationSpeed /= 2f;
        }
        CurrentState = BadInsectState.TowardsFood;
    }

    public void GoToWindState(float windPower)
    {
        this.windPower = windPower;
        GoToFlyState();
        CurrentState = BadInsectState.Wind;
        StartCoroutine(GoBackToNormal());
    }
    #endregion

    private void MoveAgainstCake()
    {
        rigidBody2d.AddForce((transform.position - cakePoint.transform.position).normalized * windPower, ForceMode2D.Impulse);
    }
    
    protected override void OnDisable()
    {
        base.OnDisable();
        CurrentState = BadInsectState.Stop;
    }
    
    private IEnumerator GoBackToNormal()
    {
        yield return new WaitForSeconds(0.6f);
        GoToFlyState();
    }
}
