using System;
using UnityEngine;

[Serializable]
public class WeaponData
{
    [SerializeField]
    [Tooltip("��� �����")]
    public LayerMask targetMask;

    [SerializeField]
    [Tooltip("������ �����")]
    public float attackRange;

    [SerializeField]
    [Tooltip("���������� ��������� � �������")]
    public float shootsPerSecond;

    [SerializeField]
    [Tooltip("����")]
    public BulletData bulletData;
}
