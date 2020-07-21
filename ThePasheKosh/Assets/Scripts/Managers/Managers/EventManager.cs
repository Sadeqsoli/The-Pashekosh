using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{

    public bool IsInitialized { get; private set; } = false;

    ///<summary>
    /// Define a dictionary to save events
    /// </summary>
    Dictionary<string, UnityAction> _noParameterEvents;
    Dictionary<string, UnityAction<Vector3>> _vector3Events;
    Dictionary<string, UnityAction<GameObject>> _gameObjectEvents;

    void Start()
    {
        _noParameterEvents = new Dictionary<string, UnityAction>();
        _vector3Events = new Dictionary<string, UnityAction<Vector3>>();
        _gameObjectEvents = new Dictionary<string, UnityAction<GameObject>>();
        IsInitialized = true;
    }


    /// <summary>
    /// Adding events to the dictionary
    /// </summary>
    public void AddNoParameterEvent(string eventName)
    {
        UnityAction newEvent = null;
        _noParameterEvents.Add(eventName, newEvent);
    }
    public void AddVector3Event(string eventName)
    {
        UnityAction<Vector3> newEvent = null;
        _vector3Events.Add(eventName, newEvent);
    }
    public void AddGameObjectEvent(string eventName)
    {
        UnityAction<GameObject> newEvent = null;
        _gameObjectEvents.Add(eventName, newEvent);
    }

    /// <summary>
    /// Removing Events
    /// </summary>
    public void RemoveNoParameterEvent(string eventName)
    {
        if (_noParameterEvents.ContainsKey(eventName))
        {
            _noParameterEvents.Remove(eventName);
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + " to remove.");
        }
    }
    public void RemoveVector3Event(string eventName)
    {
        if (_vector3Events.ContainsKey(eventName))
        {
            _vector3Events.Remove(eventName);
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + " to remove.");
        }
    }
    public void RemoveGameObjectEvent(string eventName)
    {
        if (_gameObjectEvents.ContainsKey(eventName))
        {
            _gameObjectEvents.Remove(eventName);
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + " to remove.");
        }
    }
    /// <summary>
    ///  Adding listeners to the dictionary
    /// </summary>
    public void AddListeners(string eventName, UnityAction listenerFunctions)
    {
        if (_noParameterEvents.ContainsKey(eventName))
        {
            _noParameterEvents[eventName] += listenerFunctions;
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + ". Add events before adding listeners.");
        }
    }
    public void AddListeners(string eventName, UnityAction<Vector3> listenerFunctions)
    {
        if (_vector3Events.ContainsKey(eventName))
        {
            _vector3Events[eventName] += listenerFunctions;
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + ". Add events before adding listeners.");
        }
    }
    public void AddListeners(string eventName, UnityAction<GameObject> listenerFunctions)
    {
        if (_gameObjectEvents.ContainsKey(eventName))
        {
            _gameObjectEvents[eventName] += listenerFunctions;
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + ". Add events before adding listeners.");
        }
    }

    /// <summary>
    /// removing listener from the events
    /// </summary>
    public void RemoveListeners(string eventName, UnityAction listenerFunctions)
    {
        if (_noParameterEvents.ContainsKey(eventName))
        {
            try
            {
                _noParameterEvents[eventName] -= listenerFunctions;
            }
            catch (Exception e)
            {
                Debug.LogError("The event " + eventName + " doesn't contain functions to remove.");
            }
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + ".");
        }
    }
    public void RemoveListeners(string eventName, UnityAction<Vector3> listenerFunctions)
    {
        if (_vector3Events.ContainsKey(eventName))
        {
            try
            {
                _vector3Events[eventName] -= listenerFunctions;
            }
            catch (Exception e)
            {
                Debug.LogError("The event " + eventName + " doesn't contain functions to remove.");
            }
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + ".");
        }
    }
    public void RemoveListeners(string eventName, UnityAction<GameObject> listenerFunctions)
    {
        if (_gameObjectEvents.ContainsKey(eventName))
        {
            try
            {
                _gameObjectEvents[eventName] -= listenerFunctions;
            }
            catch (Exception e)
            {
                Debug.LogError("The event " + eventName + " doesn't contain functions to remove.");
            }
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + ".");
        }
    }

    /// <summary>
    /// Invoking the events
    /// </summary>
    public void InvokeEvent(string eventName)
    {
        if (_noParameterEvents.ContainsKey(eventName))
        {
            _noParameterEvents[eventName].Invoke();
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + ". Add events before invoking.");
        }
    }
    public void InvokeEvent(string eventName, Vector3 pos)
    {
        if (_noParameterEvents.ContainsKey(eventName))
        {
            _vector3Events[eventName].Invoke(pos);
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + ". Add events before invoking.");
        }
    }
    public void InvokeEvent(string eventName, GameObject gameObject)
    {
        if (_gameObjectEvents.ContainsKey(eventName))
        {
            _gameObjectEvents[eventName].Invoke(gameObject);
        }
        else
        {
            Debug.LogError("There is no event with name of " + eventName + ". Add events before invoking.");
        }
    }

    /// <summary>
    /// Removing All the events
    /// </summary>
    public void RemoveAllEvents()
    {
        _noParameterEvents.Clear();
        _vector3Events.Clear();
        _gameObjectEvents.Clear();
    }


}
