using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public abstract class ABullet : MonoBehaviour
{
    [field: Header("Components")]
    [field: SerializeField] protected Rigidbody2D rigidbody { get; private set; }
    [field: SerializeField] protected CircleCollider2D collider { get; private set; }

    protected BulletData data { get; private set; }
    protected LayerMask targetLayer { get; private set; }
    protected Vector2 direction { get; private set; }

    protected abstract void Update();
    protected abstract void Movement();
    protected abstract void Release();

    public void Init(BulletData data, LayerMask layer, Vector2 direction)
    {
        this.data = data;
        targetLayer = layer; 
        this.direction = direction;

        CancelInvoke();
        Invoke(nameof(Release), data.lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerInLayerMask(collision.gameObject.layer, targetLayer))
        {
            if (collision.TryGetComponent(out HealthComponent health))
            {
                health.TakeDamage(data.damage);
                Release();
            }
        }
    }

    private bool IsLayerInLayerMask(int layer, LayerMask layerMask)
    {
        return (layerMask.value & (1 << layer)) != 0;
    }
}
