using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParvaneController : MonoBehaviour
{
    #region Public Variables
    public float vSpeed = 2f;
    public float hSpeed = 2f;
    public float flySpeed = 2f;
    public GameObject particalePrefab;
    private Transform target;

    #endregion

    #region  Private Variables
    private float direction = 0; // 1 => right , -1 => left , 0 
    private float direction1 = 0; // 1 => up , -1 => down , 0 
    private bool onlyOnce = false;
    private int moveTowardCounter = 0;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {

    }//Startttttt



    private void CheckParvaneOutOfBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -8.5f, 8.5f);
        pos.y = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = pos;
        if (pos.x >= 8.3f || pos.x <= -8.3f || pos.y >= 4.3f || pos.y <= -4.3f)
        {
            Invoke("ChangeDirection", 0.0001f);
        }
    }
    private void ChangeDirection()
    {
        direction = Random.Range(-1f, 2f); // -1 , 0 , 1
        direction1 = Random.Range(-1f, 2f); // -1 , 0 , 1
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pashekosh"))
        {
            Instantiate(particalePrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }


    

    private void Update()
    {
        RandomWalkTowardsCake();
    } ////////////////Update

    private void RandomWalkTowardsCake()
    {
        var lastTransfromPosition = transform.position;
        float speed = 0;
        moveTowardCounter++;


        
        if (moveTowardCounter < 100)
        {
            speed = flySpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
            if (transform.position == target.position) Destroy(gameObject);
        }
        else if (Random.Range(0f, 1f) > 0.7 && moveTowardCounter > 120)
        {
            moveTowardCounter = 0;
            ChangeDirection();
        }

        else
        {
            Vector3 move = Vector3.down;
            move.x = direction * hSpeed;
            move.y = direction1 * vSpeed;
            transform.position += move * Time.deltaTime;
        }

        var newTransformPosition = transform.position;

        RotationRectifying(lastTransfromPosition, newTransformPosition);

        CheckParvaneOutOfBounds();
    }

    private void RotationRectifying(Vector3 lastTransfromPosition, Vector3 newTransformPosition)
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

    private void DestroyParvane()
    {
        Destroy(gameObject);
    }

    #endregion
}//EndClasssss
