using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    #region Fields
    #region Protected variables
    [SerializeField] protected float vSpeed = 2f;
    [SerializeField] protected float hSpeed = 2f;
    [SerializeField] protected float flySpeed = 2f;
    [SerializeField] protected float walkSpeed = 1f;
    [SerializeField] protected Animator anim;

    protected float direction = 0; // 1 => right , -1 => left , 0 
    protected float direction1 = 0; // 1 => up , -1 => down , 0 
    #endregion
    #endregion

    #region Properties
    #endregion

    #region Methods

    #region Protected Methods

    protected abstract void RandomWalkTowardsCake();
    protected abstract void RotationRectifying(Vector3 lastTransfromPosition, Vector3 newTransformPosition);
    protected abstract void OnCollisionEnter2D(Collision2D collision);
    protected void ChangeDirection()
    {
        direction = Random.Range(-1f, 2f); // -1 , 0 , 1
        direction1 = Random.Range(-1f, 2f); // -1 , 0 , 1
    }

    protected void CheckOutOfBounds()
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
    #endregion

    #region Public Methods

    #endregion

    #endregion

}
