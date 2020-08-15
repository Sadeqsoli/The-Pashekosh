using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    public bool isBadInsect;

    Vector2 _endPoint;

    float _speed;

    bool _isInitialized = false;

    public void Initialize(Vector2 endPoint, float speedOfInsect)
    {
        _endPoint = endPoint;
        _speed = speedOfInsect;
        _isInitialized = true;
    }

    void Update()
    {
        if (_isInitialized)
        {
            GoToEndPoints();
        }
    }

    void GoToEndPoints()
    {
        Vector2 targetDir = (_endPoint - (Vector2) transform.position).normalized;
        float angle = targetDir.x * targetDir.y < 0? Vector2.Angle(targetDir, Vector2.up) : -Vector2.Angle(targetDir, Vector2.up);
        
        transform.rotation = Quaternion.Euler(0, 0, angle);

        Vector2 lastPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, _endPoint, _speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        _isInitialized = false;
    }
}
