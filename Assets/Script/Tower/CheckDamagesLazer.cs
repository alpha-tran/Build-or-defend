using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDamagesLazer : MonoBehaviour
{

    [SerializeField] private float _damage;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private GameObject _transformPosition;

    public void SetPerant(Collider other)
    {
        DeliverDamage(other);
        var a = Instantiate(_explosionEffect, new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), Quaternion.identity);
        Destroy(a, 0.05f);
    }

    public void DeliverDamage(Collider victim)
    {
        var health = victim.GetComponentInParent<Health>();
        if (health != null)
        {
            health.ApplyDamage(_damage * Time.deltaTime);
        }
    }

    public void SetPositionColliderCheckAnimEnemy(Transform transform)
    {
        var a = Instantiate(_transformPosition, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
        Destroy(a, 0.001f);
    }
}
