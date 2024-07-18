using System;
using UnityEngine;

[Serializable]
public class EnemyWaveData
{
    [SerializeField]
    [Tooltip("����������� ���������� ������� ���� �� ���������� �����")]
    public int waveEndMin;
    [SerializeField]
    [Tooltip("������������ ���������� ������� ���� �� ���������� �����")]
    public int waveEndMax;

    [SerializeField]
    [Tooltip("����� �� ������ ���")]
    public float waveStartingTime;

    [SerializeField]
    [Tooltip("����������� ����� ����� ��������")]
    public float spawnTimeMin;
    [SerializeField]
    [Tooltip("������������ ����� ����� ��������")]
    public float spawnTimeMax;
}
