using System;
using UnityEngine;

[Serializable]
public class BulletData
{
    [SerializeField]
    [Tooltip("Урон")]
    [Range(0, 30)]
    public float damage;

    [SerializeField]
    [Tooltip("Скорость полета пули")]
    [Range(0, 20)]
    public float speed;

    [SerializeField]
    [Tooltip("Продолжительность жизни пулим")]
    [Range(0, 20)]
    public float lifetime;
}
