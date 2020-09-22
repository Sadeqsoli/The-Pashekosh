using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BadInsectState { TowardsCake, OnCake, Stop }


public class BadInsect : Insect
{
    public int addedPoints;
    public int impactRate;

    public bool IsOnCake { get; private set; }

    public BadInsectState CurrentState { get; private set; }

    protected override void Update()
    {
        base.Update();

        switch (CurrentState)
        {
            case BadInsectState.TowardsCake:
                Move();
                break;
            case BadInsectState.OnCake:
                rigidBody2d.velocity = new Vector2(0, 0);
                Move();
                break;
            case BadInsectState.Stop:
                break;
        }

        if (cakeCollider != null && !cakeCollider.IsTouching(colliderComponent))
        {
            cakeCollider = null;
            if (CurrentState == BadInsectState.OnCake) GoToFlyState();
        }
    }

    public void Initialize(Vector2 endPoint, float speedOfInsect, float rotationSpeed, float randomDirectionPercent)
    {
        CurrentState = BadInsectState.TowardsCake;
        GoToFlyState();

        Initialize(endPoint, null, speedOfInsect, rotationSpeed, randomDirectionPercent);
        isBadInsect = true;
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
        CurrentState = BadInsectState.OnCake;
    }

    public void GoToFlyState()
    {

        if (animatorComponent != null)
        {
            animatorComponent.SetBool("OnCake", false);
        }
        if (CurrentState == BadInsectState.OnCake)
        {
            _speed *= 10;
            _rotationSpeed /= 2f;
        }
        CurrentState = BadInsectState.TowardsCake;
    }
    #endregion

    protected override void OnDisable()
    {
        base.OnDisable();
        CurrentState = BadInsectState.Stop;
    }
}
