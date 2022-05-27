using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GoodInsectState { Move, Wind}

public class GoodInsect : Insect
{
    //public int addedPoints;
    public float windPower;

    public GoodInsectState CurrentState { get; private set; }
    
    protected override void Update()
    {
        base.Update();

        switch (CurrentState)
        {
            case GoodInsectState.Move:
                Move();
                break;
            case GoodInsectState.Wind:
                MoveAgainstCake();
                break;
        }
    }

    public void Initialize(Collider2D[] targetsCollider, float speedOfInsect, float rotationSpeed, float randomDirectionPercent)
    {
        int randomIdx = Random.Range(0, targetsCollider.Length);
        GameObject targetGO = targetsCollider[randomIdx].gameObject;

        Initialize(targetGO.transform.position, targetsCollider, speedOfInsect, rotationSpeed, randomDirectionPercent);
        IsBadInsect = false;
    }

    public void GoToWindState(float windPower)
    {
        this.windPower = windPower;
        CurrentState = GoodInsectState.Wind;
        StartCoroutine(GoBackToNormal());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsBadInsect && targetsCollider != null)
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

    private void MoveAgainstCake()
    {
        rigidBody2d.AddForce((transform.position - cakePoint.transform.position).normalized * windPower, ForceMode2D.Impulse);
    }

    protected override IEnumerator ChangeDirectionCo()
    {
        float counter = 0;
        while (true)
        {
            float randomness = FProb(counter, 5f, 3f);
            ChangeDirection(randomness);
            yield return new WaitForSeconds(1f);
            counter += 1f;
        }
    }

    private IEnumerator GoBackToNormal()
    {
        yield return new WaitForSeconds(0.6f);
        CurrentState = GoodInsectState.Move;
    }
}
