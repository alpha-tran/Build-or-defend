using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamge : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent<Health>(out var Health))
        {
            Health.ApplyDamage(damage);
        }

        CreateExplosion();
        Destroy(gameObject);


    }
    private void CreateExplosion()
       => Instantiate(explosionPrefab, transform.position, transform.rotation);

    private void OnBecameInvisible() => Destroy(gameObject);
}
