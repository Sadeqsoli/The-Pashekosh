using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    void Start()
    {
        if (EventManager.Instance.IsInitialized)
        {
            // Addig a event with a GameObject parameter. 
            // Every time the player touch (or click) a collider this event will be invoked.
            EventManager.Instance.AddGameObjectEvent("TouchedGameObject");
            // Every time the player hover a collider this event will be invoked.
            EventManager.Instance.AddGameObjectEvent("HoveredGameObject");

        }
    }
}
