using UnityEngine;

public class ExplosionEffectCreator : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private float _adjustmentDistance;

    public void CreateExplosionEffectAt(Vector3 contactPoint, Vector3 normal)
    {
        if (gameObject != null)
        {
            var explosionCenter = AdjustExplosionCenter(contactPoint, normal);
            Instantiate(_explosionPrefab, explosionCenter, Quaternion.identity);
        }
    }

    private Vector3 AdjustExplosionCenter(Vector3 contactPoint, Vector3 normal)
        => contactPoint + normal * _adjustmentDistance;
}
