using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPhysics : MonoBehaviour
{
    [SerializeField] private float _explosionForce;

    public void BlowUp(Vector3 center, float radius, Collider[] victims)
    {
        foreach (var v in victims)
        {
            if (v.TryGetComponent(out Rigidbody rigid))
            {
                print("ád");
                rigid.AddExplosionForce(_explosionForce, center, radius, 1f,
                    ForceMode.Impulse);
            }
        }
    }
}
