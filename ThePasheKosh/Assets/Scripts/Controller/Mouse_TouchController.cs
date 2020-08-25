using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_TouchController : MonoBehaviour
{
    Vector2 pos;
    Camera thisCamera;

    private void Awake()
    {
        thisCamera = this.gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        //TouchHandling();
        MouseHandling();
    }

    /*public void TouchHandling()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(thisCamera.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo)
                {
                    EventManager.Instance.InvokeEvent("TouchedGameObject", hitInfo.collider.gameObject);

                    // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                }
            }
        }
    }
    */
    public void MouseHandling()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(thisCamera.ScreenToWorldPoint(pos), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo)
            { 
                EventManager.TriggerEvent("TouchedGameObject", hitInfo.collider.gameObject);
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }
        }
    }
}
