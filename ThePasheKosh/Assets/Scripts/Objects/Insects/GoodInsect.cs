using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodInsect : Insect
{
    protected override void Update()
    {
        base.Update();
        Move();
    }

    public void Initialize(Collider2D[] targetsCollider, float speedOfInsect, float rotationSpeed, float randomDirectionPercent)
    {
        int randomIdx = Random.Range(0, targetsCollider.Length);
        GameObject targetGO = targetsCollider[randomIdx].gameObject;

        Initialize(targetGO.transform.position, targetsCollider, speedOfInsect, rotationSpeed, randomDirectionPercent);
        IsBadInsect = false;
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
}
