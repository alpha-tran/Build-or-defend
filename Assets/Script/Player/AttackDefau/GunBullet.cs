﻿using System.Collections;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [Header("Đạn")]
    [SerializeField] private float _launchingForce;
    [SerializeField] private float _shootingInterval;
    [SerializeField] private float _rotationSpeed = 5f;

    [Header("Kiểm tra kẻ thù")]
    [SerializeField] private Transform _transformCheck;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private LayerMask _mask;

    [Header("Sinh ra đạn")]
    [SerializeField] protected Transform _insTransform;
    [SerializeField] protected GameObject _prefabBullet;
    [SerializeField] private float _timeDelay = 3f;

    private Transform _targetEnemy;
    private bool _isDestroyed;
    private GameObject _bullet;

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    private void Update()
    {
        if (_bullet != null && _targetEnemy != null)
        {
            Vector3 direction = _targetEnemy.position - _bullet.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _bullet.transform.rotation = Quaternion.Slerp(_bullet.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void CheckEnemy()
    {
        Collider[] detectedEnemies = Physics.OverlapSphere(_transformCheck.position, _radius, _mask, QueryTriggerInteraction.Collide);
        if (detectedEnemies.Length > 0)
        {
            _targetEnemy = detectedEnemies[0].transform;
        }
        else
        {
            _targetEnemy = null;
        }
    }

    private IEnumerator ForceBullet()
    {
        if (!_isDestroyed && _targetEnemy != null)
        {
            _bullet = Instantiate(_prefabBullet, _insTransform.position, _insTransform.rotation, transform);
            yield return new WaitForSeconds(_timeDelay);

            if (_bullet != null && !_isDestroyed && _targetEnemy != null)
            {
                _bullet.transform.SetParent(null);
                Rigidbody rb = _bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = _targetEnemy.position - _bullet.transform.position;
                    rb.AddForce(direction.normalized * _launchingForce, ForceMode.Impulse);
                }
            }
            else
            {
                Destroy(_bullet, 5f); // Ensure the bullet is destroyed after a period
                _bullet = null; // Reset bullet after launching
            }
        }
    }

    private IEnumerator ShootCoroutine()
    {
        while (!_isDestroyed)
        {
            CheckEnemy();
            if (_targetEnemy != null && _bullet == null)
            {
                StartCoroutine(ForceBullet());
            }
            yield return new WaitForSeconds(_shootingInterval);
        }
    }

    private void OnDrawGizmos()
    {
        if (_transformCheck != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_transformCheck.position, _radius);
        }
    }

    private void OnDestroy()
    {
        _isDestroyed = true;
    }
}
