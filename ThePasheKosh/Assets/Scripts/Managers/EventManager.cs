using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


public class UnityEventGameObject : UnityEvent<GameObject> { }

public class EventManager : Singleton<EventManager>
{
    public static bool IsInitialized { get; private set; } = false;
    private Dictionary<string, UnityEvent> noParameterEventDictionary;
    private Dictionary<string, UnityEvent<GameObject>> gameObjectEventDictionary;

    protected void Start()
    {
        if (noParameterEventDictionary == null) 
            noParameterEventDictionary = new Dictionary<string, UnityEvent>();
        if (gameObjectEventDictionary == null) 
            gameObjectEventDictionary = new Dictionary<string, UnityEvent<GameObject>>();
        IsInitialized = true;
    }

    #region noParameter Events
    public static void AddEventWithNoParamter(string eventName)
    {
        UnityEvent newEvent = new UnityEvent();
        Instance.noParameterEventDictionary.Add(eventName, newEvent);
    }
    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Instance.noParameterEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.noParameterEventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Instance.noParameterEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent;
        if (Instance.noParameterEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent?.Invoke();
        }
    }
    #endregion

    #region  Events with one GameObject parameter
    public static void AddGameObjectEvent(string eventName)
    {
        UnityEvent<GameObject> newEvent = new UnityEventGameObject();
        Instance.gameObjectEventDictionary.Add(eventName, newEvent);
    }
    public static void StartListening(string eventName, UnityAction<GameObject> listener)
    {
        UnityEvent<GameObject> thisEvent;
        if (Instance.gameObjectEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEventGameObject();
            thisEvent.AddListener(listener);
            Instance.gameObjectEventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<GameObject> listener)
    {
        UnityEvent<GameObject> thisEvent;
        if (Instance.gameObjectEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, GameObject gameObject)
    {
        UnityEvent<GameObject> thisEvent;
        if (Instance.gameObjectEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent?.Invoke(gameObject);
        }
    }
    #endregion
}

