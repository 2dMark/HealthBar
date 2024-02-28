using UnityEngine;
using UnityEngine.UI;

public class SlideHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _health.AmountChanged += RefreshData;
        _slider.minValue = 0;
        _slider.maxValue = _health.MaxHealthAmount;

        RefreshData();
    }

    private void OnDisable()
    {
        _health.AmountChanged -= RefreshData;
    }

    private void RefreshData() => _slider.value = _health.HealthAmount;
}
