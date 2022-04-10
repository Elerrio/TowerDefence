using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint = null;
    [SerializeField] private GameObject _projectile = null;
    [SerializeField] private float _health = 10f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private SphereCollider _rangeColl = null;
    [SerializeField] private float _range = 10;
    [SerializeField] private int _coins = 10;

    private List<Mob> _targetList = new List<Mob>();
    private Mob _Currentarget = null;

    private float _time = 0;

    private void Start()
    {
        _targetList.Clear();
        _rangeColl.radius = _range;
    }

    private void FixedUpdate()
    {
        if (_Currentarget == null)
            return;

        _time += Time.deltaTime;

        if( _time < 0.2f)
        {
            Debug.Log("Damage Done ");
            _targetList[0].DamageDone(1);
        }

        transform.LookAt(_Currentarget.transform);
    }

    private void SetTarget(Mob target)
    {
        _targetList.Add(target);

        int count = _targetList.Count;

        _Currentarget = _targetList[count -1];
    }

    public void RemoveTarget(Mob target)
    {
        _targetList?.Remove(target);

        int count = _targetList.Count;

        if(count > 0)
            _Currentarget = _targetList[count -1];
        else
            _Currentarget = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.layer.Equals(7))
            return;

        SetTarget(other.GetComponent<Mob>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.layer.Equals(7))
            return;

        RemoveTarget(other.GetComponent<Mob>());
    }
}