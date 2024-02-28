using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSlideHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothSlideDelta = 0.5f;

    private void Start()
    {
        _health.AmountChanged += RefreshData;
        _slider.minValue = 0;
        _slider.maxValue = _health.MaxHealthAmount;
        _slider.value = _health.HealthAmount;
    }

    private void OnDisable()
    {
        _health.AmountChanged -= RefreshData;

        StopCoroutine(SmoothChangeSliderValue());
    }

    private void RefreshData() => StartCoroutine(SmoothChangeSliderValue());

    private IEnumerator SmoothChangeSliderValue()
    {
        while (_slider.value != _health.HealthAmount)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.HealthAmount, _smoothSlideDelta * Time.deltaTime);

            yield return null;
        }
    }
}