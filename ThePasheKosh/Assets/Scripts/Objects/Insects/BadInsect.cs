using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BadInsectState { TowardsFood, OnFood, Stop }


public class BadInsect : Insect
{
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
            case BadInsectState.Stop:
                break;
        }

        if (foodCollider != null && !foodCollider.IsTouching(colliderComponent))
        {
            foodCollider = null;
            if (CurrentState == BadInsectState.OnFood) GoToFlyState();
        }
    }

    public void Initialize(Vector2 endPoint, float speedOfInsect, float rotationSpeed, float randomDirectionPercent)
    {
        CurrentState = BadInsectState.TowardsFood;
        GoToFlyState();

        Initialize(endPoint, null, speedOfInsect, rotationSpeed, randomDirectionPercent);
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
    #endregion

    protected override void OnDisable()
    {
        base.OnDisable();
        CurrentState = BadInsectState.Stop;
    }
}
