using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public float StartHealth {  get; private set; }
    public float CurrentHealth { get; private set; }

    /// <summary>
    /// <para>1) - Стартовый HP</para>
    /// <para>1) - Текущий HP</para>
    /// </summary>
    public UnityEvent<float, float> onHealthChanged;
    /// <summary>
    /// 1) - Полученный урон
    /// </summary>
    public UnityEvent<float> onTakeDamage;
    public UnityEvent onDied;

    public void Set(float health)
    {
        StartHealth = health;
        CurrentHealth = StartHealth;

        onHealthChanged?.Invoke(StartHealth, CurrentHealth);
    }
    public void TakeDamage(float damage)
    {
        if (CurrentHealth == 0)
        {
            return;
        }

        float takedDamage = Mathf.Abs(Mathf.Min(CurrentHealth - damage, damage));
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);

        onTakeDamage?.Invoke(takedDamage);
        onHealthChanged?.Invoke(StartHealth, CurrentHealth);

        if (CurrentHealth == 0)
        {
            onDied?.Invoke();
        }
    }
}