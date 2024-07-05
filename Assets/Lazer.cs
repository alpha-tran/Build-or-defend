using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    [SerializeField] private float _damage;
    public void setPerant(Transform positionEnemy,Collider other)
    {
        gameObject.transform.position = positionEnemy.position;
        DeliverDamage(other);
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
