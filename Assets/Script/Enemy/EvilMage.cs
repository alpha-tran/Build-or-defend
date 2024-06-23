using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMage : MonoBehaviour
{
    [Header("đạn")]
    [SerializeField] private float _launchingForce; // Lực bắn
    [SerializeField] private float _shootingInterval; // Thời gian giữa các lần bắn
    [SerializeField] private float _rotationSpeed = 5f; // Tốc độ quay

    [Header("sinh ra đạn")]
    [SerializeField] protected Transform _insTransform; // vị trí sinh ra
    [SerializeField] protected GameObject _prefabBullet; // model

    private Transform _targetTower; 


    private GameObject CreateInstantiate() => Instantiate(_prefabBullet, _insTransform.position, _insTransform.rotation);


    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Check();
            yield return new WaitForSeconds(_shootingInterval);
        }


    }

    private void Check() // kiểm tra có enemy nào trong phạm vi không
    {
        //Collider[] _checkRange = _rangeEnemy.CheckTower();
        //foreach (var enemy in _checkRange)
        //{


        //    _targetTower = enemy.transform; 
        //    RotationBullet(_targetTower);
        //    ForceBullet();
        //    break;

        //}


    }
    private void ForceBullet()
    {
        var bullet = CreateInstantiate();
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(_insTransform.forward * _launchingForce, ForceMode.Impulse);
        }
    }

    private void RotationBullet(Transform _target)
    {

        if (_target != null)
        {
            Vector3 direction = _target.position - _insTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _insTransform.rotation = Quaternion.Lerp(_insTransform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }

   
}
