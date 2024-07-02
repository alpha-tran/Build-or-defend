using UnityEngine;
using UnityEngine.UI;

public class MaskedHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private RectTransform _mask;
    [SerializeField] private float _visibleDuration;

    private Vector2 _originalSize;

    private void Start()
    {
        _originalSize = _mask.sizeDelta;
        UpdateValue();
        _health.ValueChanged.AddListener(UpdateValue);
        _health.DamageTaken.AddListener(_ => Show());
        Hide();
    }

    private void UpdateValue()
    {
        if (_health.MaxHealthPoint == 0) return;
        float fillRate = (float)_health.HealthPoint / _health.MaxHealthPoint;
        _mask.sizeDelta = new Vector2(_originalSize.x * fillRate, _originalSize.y);
    }

    private void Show()
    {
        gameObject.SetActive(true);
        CancelInvoke();
        Invoke(nameof(Hide), _visibleDuration);
    }

    private void Hide() => gameObject.SetActive(false);
}
