using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] private Image fill;
    private HealthComponent healthComponent;

    public void Init(HealthComponent healthComponent)
    {
        this.healthComponent = healthComponent;
        this.healthComponent.onHealthChanged.AddListener(UpdateBar);
    }

    private void UpdateBar(float startHealth, float currentHealth)
    {
        float onePercent = startHealth / 100;
        float currentPercent = currentHealth / onePercent;
        float result = currentPercent / 100;
        fill.fillAmount = result;
    }
}
