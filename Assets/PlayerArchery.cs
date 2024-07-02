using UnityEngine;
public class PlayerArchery : TakeDamage
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DeliverDamage(other);
            Destroy(gameObject);
            Instantiate(_explosionEffect, other.transform.position, Quaternion.identity);
        }

    }

    public void DeliverDamage(Collider victim)
    {
        var health = victim.GetComponentInParent<Health>();
        if (health != null)
        {
            health.ApplyDamage(_damage);
        }
    }

    public void CreateExplosionEffect()
    {
        
    }
}


