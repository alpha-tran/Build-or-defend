using UnityEngine;
public class PlayerArchery :MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _explosionEffect;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DeliverDamage(other);
            Destroy(gameObject);
            var a = Instantiate(_explosionEffect, other.transform.position, Quaternion.identity);
            Destroy(a, 4f);
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

   
}


