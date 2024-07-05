using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealthPoint;
    public float MaxHealthPoint => _maxHealthPoint;

    public UnityEvent Dead;
    public UnityEvent<float> DamageTaken;
    public UnityEvent ValueChanged;

    private float _healthPoint;
    public float HealthPoint
    {
        get => _healthPoint;
        private set
        {
            if (Mathf.Abs(_healthPoint - value) > Mathf.Epsilon)
            {
                _healthPoint = Mathf.Clamp(value, 0, MaxHealthPoint);
                ValueChanged.Invoke();
                if (IsDead)
                {
                    Die();
                }
            }
        }
    }

    private void Start()
    {
        HealthPoint = MaxHealthPoint;
    }

    public bool CanTakeDamage()
    {
        return !IsDead;
    }

    public void ApplyDamage(float damage)
    {
        if (!CanTakeDamage()) return;

        HealthPoint -= damage;
        DamageTaken?.Invoke(damage);
    }

    public bool IsDead => HealthPoint <= 0;

    public void Die()
    {
        Dead.Invoke();
        // Implement any death-related logic here
    }
}
