using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    public bool isBadInsect;

    Vector2 _endPoint;
    Quaternion _direction;
    
    float _speed;

    bool _isInitialized = false;

    int _counter;

    public void Initialize(Vector2 endPoint, float speedOfInsect)
    {
        _endPoint = endPoint;
        _speed = speedOfInsect;
        _isInitialized = true;
        _counter = 0;
    }

    void Update()
    {
        if (_isInitialized)
        {
            if (Random.value > 0.95f)
            {
                ChangeDirection();
            }
            Rotate();
            GoDirect();
        }
    }

    void GoToEndPoints()
    {
        Vector2 targetDir = (_endPoint - (Vector2) transform.position).normalized;
        float angle = targetDir.x < 0? Vector2.Angle(targetDir, Vector2.up) : -Vector2.Angle(targetDir, Vector2.up);
        
        transform.rotation = Quaternion.Euler(0, 0, angle);

        Vector2 lastPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, _endPoint, _speed * Time.deltaTime);
    }

    void GoDirect()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
    void ChangeDirection()
    {
        Vector2 targetDir = (_endPoint - (Vector2)transform.position).normalized;
        Vector2 randomDir = new Vector2(Random.Range(-1,1), Random.Range(-1, 1)).normalized;
        Vector2 mean = ((targetDir + randomDir)/3).normalized;
        float angle = mean.x < 0 ? Vector2.Angle(mean, Vector2.up) : -Vector2.Angle(mean, Vector2.up);
        _direction = Quaternion.Euler(0, 0, angle);
    }
    void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _direction, 20 * Time.deltaTime);
    }

    private void OnDisable()
    {
        _isInitialized = false;
    }
}
