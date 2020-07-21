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
        TouchHandling();
        MouseHandling();
    }

    public void TouchHandling()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo)
                {
                    EventManager.Instance.InvokeEvent("TouchedGameObject", hitInfo.collider.gameObject);
                    // Here you can check hitInfo to see which collider has been hit, and act appropriately.
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

                EventManager.Instance.InvokeEvent("TouchedGameObject", hitInfo.collider.gameObject);
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }
        }
        else
        {
            pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            if (hitInfo)
            {
                EventManager.Instance.InvokeEvent("HoveredGameObject", hitInfo.collider.gameObject);
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }
        }
    }
}
