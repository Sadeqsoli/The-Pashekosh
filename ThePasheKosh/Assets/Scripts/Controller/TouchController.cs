using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{
    
    public WeaponType usingWeapon;

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
        if (Input.touchCount>0 && GameManager.Instance.IsTouchable)
        {
            var weaponPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!(Camera.main is null))
                {
                    RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                    // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                    if (hitInfo)
                    {
                        if (!hitInfo.collider.CompareTag("Button"))
                        {
                            EventManager.TriggerEvent(Events.TouchCollider, hitInfo.collider.gameObject);
                            // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                            ShowImpact(weaponPos);
                        }
                    }
                    else
                    {
                        EventManager.TriggerEvent(Events.TouchScreen);
                        ShowImpact(weaponPos);
                    }
                }
            }
        }
    }

    public void MouseHandling()
    {
        if (Input.GetMouseButtonUp(0) && GameManager.Instance != null && GameManager.Instance.IsTouchable)
        {
            pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f);

            var weaponPos = Camera.main.ScreenToWorldPoint(pos);
            
            if (!(Camera.main is null))
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo)
                {
                    if (!hitInfo.collider.CompareTag("Button"))
                    {
                        EventManager.TriggerEvent(Events.TouchCollider, hitInfo.collider.gameObject);
                        // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                        ShowImpact(weaponPos);
                    }
                }
                else
                {
                    EventManager.TriggerEvent(Events.TouchScreen);
                    ShowImpact(weaponPos);
                }
            }
        }
    }

    public void ShowImpact(Vector3 weaponPos)
    {
        ItemPool.InstantiateGameObjectByName(usingWeapon.ToString(), weaponPos, quaternion.identity);
    }
}