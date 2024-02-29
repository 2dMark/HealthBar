using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected TMP_Text _text;

    protected virtual void Awake()
    {
        RefreshData();
    }

    protected virtual void OnEnable()
    {
        _health.AmountChanged += RefreshData;
    }

    protected virtual void OnDisable()
    {
        _health.AmountChanged -= RefreshData;
    }

    protected virtual void RefreshData()
    {
        if (_health.IsAlive)
            _text.text = $"< {_health.Amount} / {_health.MaxAmount} >";
        else
            _text.text = $"< Dead >";
    }
}