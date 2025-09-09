using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int startHealth = 100;

    public int Current { get; private set; }

    // Events (publisher)
    public event Action<int, int> OnHealthChanged; // current, max
    public event Action<int> OnDamaged;           // amount
    public event Action<int> OnHealed;            // amount
    public event Action OnDied;

    private void Awake()
    {
        Current = Mathf.Clamp(startHealth, 0, maxHealth);
        RaiseChanged();
    }

    public void Damage(int amount)
    {
        if (amount <= 0 || Current <= 0) return;
        Current = Mathf.Max(0, Current - amount);
        OnDamaged?.Invoke(amount);
        RaiseChanged();
        if (Current == 0) OnDied?.Invoke();
    }

    public void Heal(int amount)
    {
        if (amount <= 0 || Current <= 0) return;
        Current = Mathf.Min(maxHealth, Current + amount);
        OnHealed?.Invoke(amount);
        RaiseChanged();
    }

    private void RaiseChanged() => OnHealthChanged?.Invoke(Current, maxHealth);
}