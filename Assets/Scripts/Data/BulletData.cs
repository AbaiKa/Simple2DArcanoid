using System;
using UnityEngine;

[Serializable]
public class BulletData
{
    [SerializeField]
    [Tooltip("����")]
    [Range(0, 30)]
    public float damage;

    [SerializeField]
    [Tooltip("�������� ������ ����")]
    [Range(0, 20)]
    public float speed;

    [SerializeField]
    [Tooltip("����������������� ����� �����")]
    [Range(0, 20)]
    public float lifetime;
}
