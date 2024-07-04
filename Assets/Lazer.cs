using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _explosionEffect;
    public LineRenderer LaserLine;
       

    public void DeliverDamage(Collider victim)
    {
        var health = victim.GetComponentInParent<Health>();
        if (health != null)
        {
            health.ApplyDamage(_damage);
            print("abc");

        }
        Instantiate(_explosionEffect);
        Destroy(_explosionEffect,2f);
    }

   
}
