using System;
using UnityEngine;

[Serializable]
public class WeaponData
{
    [SerializeField]
    [Tooltip("Тэг врага")]
    public LayerMask targetMask;

    [SerializeField]
    [Tooltip("Радиус атаки")]
    public float attackRange;

    [SerializeField]
    [Tooltip("Количество выстрелов в секунду")]
    public float shootsPerSecond;

    [SerializeField]
    [Tooltip("Пуля")]
    public BulletData bulletData;
}
