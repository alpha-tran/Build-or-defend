using System.Collections;
using UnityEngine;

public class EvilMage : MonoBehaviour
{
    [Header("Sinh ra đạn")]
    [SerializeField] protected GameObject _prefabBullet;
    [SerializeField] private EnemyState _enemyState;

    private void Start()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (_enemyState.ShouldAttackCondition())
            {
                Transform targetTransform = _enemyState.FindNearestTarget();
                if (targetTransform != null)
                {
                    FireBall(targetTransform);
                    yield return new WaitForSeconds(2f);
                }
            }
            yield return null; 
        }
    }

    private void FireBall(Transform targetTransform)
    {
        Vector3 position = targetTransform.position + Vector3.up * -1f; 
        GameObject bullet = Instantiate(_prefabBullet, position, Quaternion.identity);
        Destroy(bullet, 1f); // Hủy đạn sau 1 giây
    }
}
