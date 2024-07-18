using System;
using UnityEngine;

[Serializable]
public class EnemyWaveData
{
    [SerializeField]
    [Tooltip("ћинимальное количество спавнов пока не закончитс€ волна")]
    public int waveEndMin;
    [SerializeField]
    [Tooltip("ћаксимальное количество спавнов пока не закончитс€ волна")]
    public int waveEndMax;

    [SerializeField]
    [Tooltip("¬рем€ до начало бо€")]
    public float waveStartingTime;

    [SerializeField]
    [Tooltip("ћинимальное врем€ между спавнами")]
    public float spawnTimeMin;
    [SerializeField]
    [Tooltip("ћаксимальное врем€ между спавнами")]
    public float spawnTimeMax;
}
