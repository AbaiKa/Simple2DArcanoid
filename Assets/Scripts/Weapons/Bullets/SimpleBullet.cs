using UnityEngine;

public class SimpleBullet : ABullet
{
    protected override void Update()
    {
        Movement();
    }
    protected override void Movement()
    {
        transform.localPosition += (Vector3)(direction * data.speed * Time.deltaTime);
    }
    protected override void Release()
    {
        FactoryManager.Instance.SimpleBulletPool.Return(this);
    }
}
