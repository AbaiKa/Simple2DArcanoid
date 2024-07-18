using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public HealthComponent Health { get; private set; }
    [SerializeField] private ZoneComponent zone;
    [SerializeField] private HealthBarComponent healthBar;
    
    public void Init(int hp)
    {
        zone.onTrigger.AddListener(OnZoneTrigger);
        healthBar.Init(Health);
        Health.Set(hp);
    }

    private void OnZoneTrigger(Collider2D collider)
    {
        if (collider.TryGetComponent(out AEnemy enemy))
        {
            Health.TakeDamage(1);
            enemy.Kill();
        }
    }
}
