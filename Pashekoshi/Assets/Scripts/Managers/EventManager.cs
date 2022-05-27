using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


public class UnityEventGameObject : UnityEvent<GameObject> { }
public class UnityEventBool : UnityEvent<bool> { }

public class EventManager : Singleton<EventManager>
{
    public static bool IsInitialized { get; private set; } = false;
    private Dictionary<string, UnityEvent> noParameterEventDictionary;
    private Dictionary<string, UnityEvent<GameObject>> gameObjectEventDictionary;
    private Dictionary<string, UnityEvent<bool>> boolEventDictionary;

    protected void Start()
    {
        if (noParameterEventDictionary == null) 
            noParameterEventDictionary = new Dictionary<string, UnityEvent>();
        if (gameObjectEventDictionary == null) 
            gameObjectEventDictionary = new Dictionary<string, UnityEvent<GameObject>>();
        if (boolEventDictionary == null)
            boolEventDictionary = new Dictionary<string, UnityEvent<bool>>();
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
            Debug.Log("The event " + eventName + " is added by the " + listener + " listener.");
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
            Debug.Log("The event " + eventName + " is added by the " + listener + " listener.");
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
    
    #region  Events with one bool parameter
    public static void AddBoolEvent(string eventName)
    {
        UnityEvent<bool> newEvent = new UnityEventBool();
        Instance.boolEventDictionary.Add(eventName, newEvent);
    }
    public static void StartListening(string eventName, UnityAction<bool> listener)
    {
        UnityEvent<bool> thisEvent;
        if (Instance.boolEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            Debug.Log("The event " + eventName + " is added by the " + listener + " listener.");
            thisEvent = new UnityEventBool();
            thisEvent.AddListener(listener);
            Instance.boolEventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<bool> listener)
    {
        UnityEvent<bool> thisEvent;
        if (Instance.boolEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, bool condition)
    {
        UnityEvent<bool> thisEvent;
        if (Instance.boolEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent?.Invoke(condition);
        }
    }
    #endregion
}

