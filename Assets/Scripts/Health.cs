using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(0)] private int _amount;
    [SerializeField, Min(1)] private int _maxAmount;

    public event Action AmountChanged;

    private void OnValidate()
    {
        _amount = Mathf.Clamp(_amount, 1, _maxAmount);
    }

    public int HealthAmount => _amount;

    public int MaxHealthAmount => _maxAmount;

    public void Heal(int amount)
    {
        _amount = Mathf.Clamp(_amount + amount, 0, _maxAmount);

        AmountChanged?.Invoke();
    }

    public void TakeDamage(int amount)
    {
        _amount = Mathf.Clamp(_amount - amount, 0, _maxAmount);

        AmountChanged?.Invoke();
    }
}