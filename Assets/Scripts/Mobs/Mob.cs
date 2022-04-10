using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private float _health = 10f;

    [SerializeField] private List<Transform> _currentTarget = new List<Transform>();
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _smoothSpeed = 1.5f;

    private float _time = 0;

    private void FixedUpdate()
    {
        if(_currentTarget.Count <= 0)
        {
            _time = 0;
            return;
        }

        _time += _smoothSpeed * (_speed * 0.0001f);

        transform.position = Vector3.Lerp(transform.position, _currentTarget[0].position, _time);

        if (Vector3.Distance(transform.position, _currentTarget[0].position) < 0.1f)
        {
            if (_currentTarget.Count > 0)
            {
                _time = 0;
                _currentTarget?.RemoveAt(0);
            }    
            else
                _currentTarget.Clear();
        }
    }

    public void DamageDone(float value)
    {
        _health -= value;

        if (_health <= 0)
            Destroy(gameObject);

    }
}
