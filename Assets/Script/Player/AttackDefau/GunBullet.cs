using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class GunBullet : MonoBehaviour
{
    [Header("đạn")]
    [SerializeField] private float _launchingForce; // Lực bắn
    [SerializeField] private float _shootingInterval; // Thời gian giữa các lần bắn
    [SerializeField] private float _rotationSpeed = 5f; // Tốc độ quay

    [Header("kiểm tra kẻ thù")]
    [SerializeField] private Transform _transformCheck; // Vị trí để kiểm tra kẻ thù
    [SerializeField] private float _radiuns = 5f; // Bán kính kiểm tra
    [SerializeField] private LayerMask _mask; // Layer của kẻ thù


    [Header("sinh ra đạn")]
    [SerializeField] protected Transform _insTransform; // vị trí sinh ra
    [SerializeField] protected GameObject _prefabBullet; // model

    private Transform _targetEnemy; // Mục tiêu kẻ thù

    private bool _enabled = false;

    private GameObject CreateInstantiate() => Instantiate(_prefabBullet, _insTransform.position, _insTransform.rotation);


    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    private void Update()
    {
       
    }



    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            CheckEnemy();
            yield return new WaitForSeconds(_shootingInterval);
        }

         
    }

    private void CheckEnemy() // kiểm tra có enemy nào trong phạm vi không
    {
        Collider[] _check = Physics.OverlapSphere(_transformCheck.position, _radiuns, _mask, QueryTriggerInteraction.Collide);// kiểm tra enemy 
        foreach (var enemy in _check)
        {


            _targetEnemy = enemy.transform; // Gán vị trí của enemy tìm được vào biến
            RotationBullet(_targetEnemy);
            ForceBullet();
            break;
            
        }


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

    private void OnDrawGizmos()
    {
        if (_transformCheck != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_transformCheck.position, _radiuns);
        }
    }


}
