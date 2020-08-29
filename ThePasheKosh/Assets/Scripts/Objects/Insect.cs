﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    public bool isBadInsect;
    public Animation killedAnimation;

    Vector2 _endPoint;
    Quaternion _direction;
    
    float _speed;

    bool _isInitialized = false;

    float _randomDirectionPercent;

    private void OnEnable()
    {
        _isInitialized = false;
    }

    void KillHandling(GameObject insect)
    {
        if (insect == this.gameObject)
        {
            if (isBadInsect)
            {
                EventManager.TriggerEvent("BadInsectKilled");
            }
            else
            {
                EventManager.TriggerEvent("GoodInsectKilled");
            }
            Pool.DestroyGameObject(this.name, this.gameObject);
            EventManager.StopListening("TouchCollider", KillHandling);
        }
    }


    public void Initialize(Vector2 endPoint, float speedOfInsect, float randomDirectionPercent)
    {
        _endPoint = endPoint;
        _speed = speedOfInsect;
        _isInitialized = true;
        _randomDirectionPercent = randomDirectionPercent;

        EventManager.StartListening("TouchCollider", KillHandling);
    }

    void Update()
    {
        if (_isInitialized)
        {
            if (Random.value > 0.95)
            {
                ChangeDirection();
            }
            Rotate();
            GoDirect();
        }
    }

    /*********
     void GoToEndPoints()
    {
        Vector2 targetDir = (_endPoint - (Vector2) transform.position).normalized;
        float angle = targetDir.x < 0? Vector2.Angle(targetDir, Vector2.up) : -Vector2.Angle(targetDir, Vector2.up);
        
        transform.rotation = Quaternion.Euler(0, 0, angle);

        Vector2 lastPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, _endPoint, _speed * Time.deltaTime);
    }**********/

    void GoDirect()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
    void ChangeDirection()
    {
        Vector2 targetDir = (_endPoint - (Vector2)transform.position).normalized;
        Vector2 randomDir = new Vector2(Random.Range(-1,1), Random.Range(-1, 1)).normalized;
        Vector2 mean = (((1 - _randomDirectionPercent) * targetDir + (_randomDirectionPercent) * randomDir)).normalized;
        float angle = mean.x < 0 ? Vector2.Angle(mean, Vector2.up) : -Vector2.Angle(mean, Vector2.up);
        _direction = Quaternion.Euler(0, 0, angle);
    }
    void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _direction, 20 * Time.deltaTime);
    }

    private void OnDisable()
    {
        /*
        if (_isInitialized)
            EventManager.StopListening("TouchCollider", KillHandling);
            */
        _isInitialized = false;
    }
}
