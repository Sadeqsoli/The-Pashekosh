using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PasheController : EnemyController
{
    #region Fields
    #region Public Variables
    #endregion

    #region  Private Variables
    private int moveTowardCounter = 0;
    private Animator animator;
    #endregion

    #endregion

    #region Public Methods
    public void IsWalking()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isFlying", false);
    }
    public void IsFlying()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isFlying", true);
    }

    #endregion

    #region Private Methods
    private void Start()
    {
        animator = GetComponent<Animator>();
    }//Startttttt
    
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pashekosh"))
        {
            DestroyPashe();
        }
    }

    private void Update()
    {
        if (isActiveAndEnabled) 
        {
            RandomWalkTowardsCake();
        }
    } ////////////////Update

    protected override void RandomWalkTowardsCake()
    {
        var lastTransfromPosition = transform.position;
        moveTowardCounter++;


        if (moveTowardCounter < 50 || animator.GetBool("isWalking"))
        {
            float speed;
            if (animator.GetBool("isWalking"))
            {
                speed = walkSpeed * Time.deltaTime;
            }
            else { 
                speed = flySpeed * Time.deltaTime;
            }
        }
        else if (Random.Range(0f, 1f) > 0.7 && moveTowardCounter > 80)
        {
            moveTowardCounter = 0;
            ChangeDirection();
        }
        else {
            Vector3 move = Vector3.down;
            move.x = direction * hSpeed;
            move.y = direction1 * vSpeed;
            transform.position += move * Time.deltaTime;
        }

        var newTransformPosition = transform.position;

        RotationRectifying(lastTransfromPosition, newTransformPosition);

        CheckOutOfBounds();
    }

    protected override void RotationRectifying(Vector3 lastTransfromPosition, Vector3 newTransformPosition)
    {
        float y2 = newTransformPosition.y;
        float y1 = lastTransfromPosition.y;
        float x2 = newTransformPosition.x;
        float x1 = lastTransfromPosition.x;
        float deltaY = y2 - y1;
        float deltaX = x2 - x1;
        var degree = Mathf.Rad2Deg * (Mathf.Atan2(deltaY, deltaX)) - 90f;
        transform.eulerAngles = new Vector3(0, 0, degree);
    }

    private void DestroyPashe()
    {
        Destroy(gameObject);
    }
    #endregion

    #region Comments
    //private void CheckPower()
    //{
    //        //gameController.AddScore(power);
    //        //gameController.AddDestroyedItems(gameObject.tag);


    //}
    #endregion
}//EndClasssss
