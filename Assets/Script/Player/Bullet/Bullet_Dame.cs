using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Dame : TakeDamage
{
    [SerializeField] private int _damage;
    private List<Health> _hitList = new List<Health>();

    private void OnTriggerEnter(Collider other)
    {
      
            DeliverDamage(new Collider[] { other });
    }

    public void DeliverDamage(Collider[] victims)
    {

        _hitList.Clear();
        foreach (Collider v in victims)
        {
            var health = v.GetComponentInParent<Health>();
            if (health != null)
            {
                if (_hitList.Contains(health)) continue;
                _hitList.Add(health);

                health.ApplyDamage(_damage);
            }
        }
    }
}
