using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    Vector2 pos;

    /// <summary>
    /// Handling Touch
    /// </summary>
    void Update()
    {
        MouseHandling();
    }

    public void TouchHandling()
    {
        if (Input.touchCount>0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo)
                {
                    EventManager.TriggerEvent("TouchedCollider", hitInfo.collider.gameObject);
                    // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                }
                else
                {
                    EventManager.TriggerEvent("TouchedScreen");
                }
            }
        }
    }

    public void MouseHandling()
    {
        if (Input.GetKeyUp(0))
        {
            pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo)
            {

                EventManager.TriggerEvent("TouchedCollider", hitInfo.collider.gameObject);
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }
            else
            {
                EventManager.TriggerEvent("TouchedScreen");
            }
        }
    }
}
