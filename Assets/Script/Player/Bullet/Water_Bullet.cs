using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Water_Bullet : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private LayerMask _hitMask;

    public UnityEvent<Vector3, Vector3> BulletExplodedAt;
    public UnityEvent<Vector3, float, Collider[]> VictimsBlewAt;
    public UnityEvent<Collider[]> VictimsFound;

    private bool _isExploded;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isExploded)
        {
            ExplodeAt(collision.contacts[0], null);
        }
    }

    public void ExplodeAt(ContactPoint contact, ExplosionEffectCreator explosionEffectCreator)
    {
        _isExploded = true;
        BulletExplodedAt?.Invoke(contact.point, contact.normal);

        var victims = Physics.OverlapSphere(transform.position, _explosionRadius, _hitMask);
        VictimsFound?.Invoke(victims);
        VictimsBlewAt?.Invoke(transform.position, _explosionRadius, victims);

        if (explosionEffectCreator != null)
        {
            explosionEffectCreator.CreateExplosionEffectAt(contact.point, contact.normal);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
