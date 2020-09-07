using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timers : Singleton<Timers>
{
    private Dictionary<string, Coroutine> _timersDict;
    private Dictionary<string, float> _coroutineTimePassed;
    private List<string> _timersNameList;

    Coroutine repeatedActionTimer;

    private int maximumTimerCounterNumber = 200;
    public int TimerCounterStartNumber { get; private set; }


    private void OnEnable()
    {
        _timersDict = new Dictionary<string, Coroutine>();
        _coroutineTimePassed = new Dictionary<string, float>();
        _timersNameList = new List<string>();
    }


    /// <summary>
    /// Starting the timer counter for the game timer. 
    /// It can Invoke everySecondsEvent every second.
    /// When it finished, the finishedTimerCounterEvent will Invoke.
    /// </summary>
    public void StartTimeCounter(int amountOfTimeInSeconds, string finishedTimerCounterEvent, string everySecondsEvent = null)
    {
        TimerCounterStartNumber = amountOfTimeInSeconds > 0 ? amountOfTimeInSeconds : 0;
        TimerCounterStartNumber = TimerCounterStartNumber < maximumTimerCounterNumber ? TimerCounterStartNumber : maximumTimerCounterNumber;
        StartCoroutine(StartGameTimer(TimerCounterStartNumber, finishedTimerCounterEvent, everySecondsEvent));
    }
    IEnumerator StartGameTimer(int timerCounterStartNumber, string finishedEvent, string eachSecondEvent = null)
    {
        int counter = timerCounterStartNumber;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            if (eachSecondEvent != null) EventManager.TriggerEvent(eachSecondEvent);
            counter--;
        }
        if(finishedEvent != null)
        EventManager.TriggerEvent(finishedEvent);
    }

    public void StartRepeatedAction(float timeBetween, UnityAction<float> Action)
    {
        repeatedActionTimer = StartCoroutine(StartGameTimer(timeBetween, Action));
    }
    
    public void StopRepeatedAction()
    {
        if (repeatedActionTimer != null)
            StopCoroutine(repeatedActionTimer);

        repeatedActionTimer = null;
    }

    IEnumerator StartGameTimer(float timeBetween, UnityAction<float> Action)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetween);
            if (Action != null) Action.Invoke(timeBetween);
        }

    }

    /// <summary>
    /// Start a timer then invoke an event
    /// </summary>
    public void StartTimer(float amountOfTimeInSecondsToWait, string nameOfEventToInvoke)
    {
        if (amountOfTimeInSecondsToWait > 0) StartCoroutine(Counting(nameOfEventToInvoke, amountOfTimeInSecondsToWait));
    }
    IEnumerator Counting(string nameOfEvent, float amountOfTimeInSecondsToWait)
    {
        yield return new WaitForSeconds(amountOfTimeInSecondsToWait);
        EventManager.TriggerEvent(nameOfEvent);
    }

    /// <summary>
    /// Start a timer then invoke an event
    /// </summary>
    public void StartTimer(float amountOfTimeInSecondsToWait, UnityAction actionToInvoke)
    {
        if (amountOfTimeInSecondsToWait > 0) StartCoroutine(Count(actionToInvoke, amountOfTimeInSecondsToWait));
    }
    IEnumerator Count(UnityAction actionToInvoke, float amountOfTimeInSecondsToWait)
    {
        yield return new WaitForSeconds(amountOfTimeInSecondsToWait);
        actionToInvoke.Invoke();
    }


    /// <summary>
    /// These Timer will start by calling StartTimer and will stop and return the amount of the time that is passed
    /// (in miliSeconds) by calling StopTimer
    /// </summary>
    /// <param name="nameOfTimer"></param>
    public void StartTimer(string nameOfTimer, float timeToWait = 0f)
    {
        if (!_timersDict.ContainsKey(nameOfTimer))
        {
            _coroutineTimePassed.Add(nameOfTimer, 0f);
            Coroutine newCoroutine = StartCoroutine(CountMiliseconds(nameOfTimer, timeToWait));
            _timersDict.Add(nameOfTimer, newCoroutine);
            _timersNameList.Add(nameOfTimer);
        }
        else
        {
            StopCoroutine(_timersDict[nameOfTimer]);
            _coroutineTimePassed[nameOfTimer] = 0f;
            Coroutine newCoroutine = StartCoroutine(CountMiliseconds(nameOfTimer, timeToWait));
            _timersDict[nameOfTimer] = newCoroutine;
        }
    }
    public float StopTimer(string nameOfTimer)
    {
        float timePassed;
        if (_coroutineTimePassed.ContainsKey(nameOfTimer))
        {
            timePassed = _coroutineTimePassed[nameOfTimer];
            _coroutineTimePassed.Remove(nameOfTimer);
            StopCoroutine(_timersDict[nameOfTimer]);
            _timersDict.Remove(nameOfTimer);
            _timersNameList.Remove(nameOfTimer);
            return timePassed;
        }
        else
        {
            Debug.LogError("There is no timer with the name " + nameOfTimer);
            return -1f;
        }
        
    }
    IEnumerator CountMiliseconds(string nameOfCoroutine, float timeToWait = 0f)
    {
        _coroutineTimePassed[nameOfCoroutine] = 0;
        float _timeToWait = timeToWait;
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (_timeToWait > 0f)
            {
                _timeToWait -= 0.1f;
            }
            else
            {
                _coroutineTimePassed[nameOfCoroutine] += 0.1f;
            }
        }
    }

    private void OnDisable()
    {
        while(_timersDict.Count > 0)
        {
            string nameOfTimer = _timersNameList[_timersNameList.Count - 1];
            StopCoroutine(_timersDict[nameOfTimer]);
            _timersDict.Remove(nameOfTimer);
            _coroutineTimePassed.Remove(nameOfTimer);
            _timersNameList.Remove(nameOfTimer);
        }
    }
}
