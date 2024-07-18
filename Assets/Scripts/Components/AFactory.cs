using System;
using UnityEngine;

[Serializable]
public abstract class AFactory<T>
{
    [field: SerializeField] protected T prefab;
    [field: SerializeField] protected Transform container;

    public abstract T Create();
}
