using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(0)] private float _amount;
    [SerializeField, Min(1)] private float _maxAmount;

    public event Action AmountChanged;

    public float Amount
    {
        get => _amount;

        private set
        {
            if (value == _amount || IsAlive == false)
                return;

            _amount = Mathf.Clamp(value, 0, _maxAmount);

            AmountChanged?.Invoke();
        }
    }

    public float MaxAmount => _maxAmount;

    public bool IsAlive => _amount > 0;

    private void OnValidate()
    {
        _amount = Mathf.Clamp(_amount, 1, _maxAmount);
    }

    public void Heal(float value) => Amount += Mathf.Round(value);

    public void TakeDamage(float value) => Amount -= Mathf.Round(value);
}