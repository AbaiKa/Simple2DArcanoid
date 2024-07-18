using UnityEngine;
public class RangedWeapon : AWeapon
{
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected ParticleSystem shootEffect;
    public override void Shoot(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        var item = FactoryManager.Instance.SimpleBulletPool.Get();
        item.transform.localPosition = transform.position;
        item.transform.localRotation = transform.rotation;
        item.Init(Data.bulletData, Data.targetMask, direction);

        shootEffect.Play();
        ResetCooldown();
    }
}
