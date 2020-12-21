using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    Vector3 pos;

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
            var weaponPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            ShowImpact(weaponPos);
            
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!(Camera.main is null))
                {
                    RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                    // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                    if (hitInfo)
                    {
                        EventManager.TriggerEvent(Events.TouchCollider, hitInfo.collider.gameObject);
                        // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                    }
                    else
                    {
                        EventManager.TriggerEvent(Events.TouchScreen);
                    }
                }
            }
        }
    }

    public void MouseHandling()
    {
        if (Input.GetMouseButtonUp(0))
        {
            pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f);

            var weaponPos = Camera.main.ScreenToWorldPoint(pos);
            ShowImpact(weaponPos);
            
            if (!(Camera.main is null))
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo)
                {
                    EventManager.TriggerEvent(Events.TouchCollider, hitInfo.collider.gameObject);
                    // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                }
                else
                {
                    EventManager.TriggerEvent(Events.TouchScreen);
                }
            }
        }
    }

    public void ShowImpact(Vector3 weaponPos)
    {
        ItemPool.InstantiateGameObjectByName("Dampaee", weaponPos, quaternion.identity);
    }
}