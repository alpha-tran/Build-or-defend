using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoint;
    public int MaxHealthPoint => _maxHealthPoint;

    public UnityEvent Dead;
    public UnityEvent<int> DamageTaken;
    public UnityEvent ValueChanged;

    private int _healthPoint;
    public int HealthPoint
    {
        get => _healthPoint;
        private set
        {
            if (_healthPoint != value)
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

    public void ApplyDamage(int damage)
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
