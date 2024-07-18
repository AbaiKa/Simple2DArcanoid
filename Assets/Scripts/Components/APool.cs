using System.Collections.Generic;
using UnityEngine;

public class APool<T> where T : Component
{
    private readonly Queue<T> objects = new Queue<T>();
    private AFactory<T> factory;

    public APool(AFactory<T> factory)
    {
        this.factory = factory;
    }

    public T Get()
    {
        if (objects.Count == 0)
        {
            return factory.Create();
        }

        T obj = objects.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        objects.Enqueue(obj);
    }

    private void AddObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Return(factory.Create());
        }
    }
}