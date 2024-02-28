using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _health.AmountChanged += RefreshData;

        RefreshData();
    }

    private void OnDisable()
    {
        _health.AmountChanged -= RefreshData;
    }

    private void RefreshData() => _text.text = $"< {_health.HealthAmount} / {_health.MaxHealthAmount} >";
}
