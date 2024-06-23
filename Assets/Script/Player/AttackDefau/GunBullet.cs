using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunBullet : MonoBehaviour
{
    [Header("Đạn")]
    [SerializeField] private float _launchingForce; // Lực bắn
    [SerializeField] private float _shootingInterval; // Thời gian giữa các lần bắn
    [SerializeField] private float _rotationSpeed = 5f; // Tốc độ quay

    [Header("Kiểm tra kẻ thù")]
    [SerializeField] private Transform _transformCheck; // Vị trí để kiểm tra kẻ thù
    [SerializeField] private float _radius = 5f; // Bán kính kiểm tra
    [SerializeField] private LayerMask _mask; // Layer của kẻ thù

    [Header("Sinh ra đạn")]
    [SerializeField] protected Transform _insTransform; // Vị trí sinh ra
    [SerializeField] protected GameObject _prefabBullet; // Model đạn

    private Transform _targetEnemy; // Mục tiêu kẻ thù

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    private void CheckEnemy() // Kiểm tra có enemy nào trong phạm vi không
    {
        Collider[] _check = Physics.OverlapSphere(_transformCheck.position, _radius, _mask, QueryTriggerInteraction.Collide); // Kiểm tra enemy
        foreach (var enemy in _check)
        {
            _targetEnemy = enemy.transform; // Gán vị trí của enemy tìm được vào biến
            RotationBullet(_targetEnemy);
            StartCoroutine(ForceBullet());
            break;
        }
    }

    private IEnumerator ForceBullet()
    {
        var bullet = Instantiate(_prefabBullet, _insTransform.position, _insTransform.rotation);
        yield return new WaitForSeconds(2f);
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

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            CheckEnemy();
            yield return new WaitForSeconds(_shootingInterval); // Chờ 2 giây trước khi bắn lần tiếp theo
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
}
