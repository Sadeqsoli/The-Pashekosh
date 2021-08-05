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
    Camera cameraTouch;


    void Awake()
    {
        cameraTouch = GetComponent<Camera>();
    }

    /// <summary>
    /// Handling Touch
    /// </summary>
    void Update()
    {
        MouseHandling();
    }

    public void TouchHandling()
    {
        if (Input.touchCount>0 && GameManager.IsNormalWeaponActive)
        {
            var weaponPos = cameraTouch.ScreenToWorldPoint(Input.GetTouch(0).position);
            
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!(cameraTouch is null))
                {
                    RaycastHit2D hitInfo = Physics2D.Raycast(cameraTouch.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
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
        if (Input.GetMouseButtonUp(0) && GameManager.Instance != null && GameManager.IsNormalWeaponActive)
        {
            pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f);

            var weaponPos = cameraTouch.ScreenToWorldPoint(pos);
            
            if (!(cameraTouch is null))
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(cameraTouch.ScreenToWorldPoint(pos), Vector2.zero);
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
        else if (Input.GetMouseButtonUp(0) && GameManager.Instance != null && GameManager.isPowerUpActive && GameManager.IsElectricalPkActive)
        {
            pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f);

            var weaponPos = cameraTouch.ScreenToWorldPoint(pos);
            
            if (!(cameraTouch is null))
            {
                ItemPool.InstantiateGameObjectByName(WeaponType.ElectricalPashekosh.ToString(), weaponPos, Quaternion.identity);
            }
        }
    }

    public void ShowImpact(Vector3 weaponPos)
    {
        ItemPool.InstantiateGameObjectByName(usingWeapon.ToString(), weaponPos, quaternion.identity);
    }
    
    
}