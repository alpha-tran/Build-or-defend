using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDamages : MonoBehaviour
{

    [SerializeField] private float _damage;
    [SerializeField] private GameObject _explosionEffect;
    public void setPerant(Collider other)
    {
        DeliverDamage(other);
        var a = Instantiate(_explosionEffect, new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), Quaternion.identity);
        Destroy(a, 0.15f);
    }

    public void DeliverDamage(Collider victim)
    {
        var health = victim.GetComponentInParent<Health>();
        if (health != null)
        {
            health.ApplyDamage(_damage * Time.deltaTime);
        }
    }
}
