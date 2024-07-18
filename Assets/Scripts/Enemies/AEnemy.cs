using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(HealthComponent))]
public abstract class AEnemy : MonoBehaviour
{
    [SerializeField] private EnemyDataSO SOProps;
    [field: SerializeField] public HealthComponent Health { get; private set; }
    [field: SerializeField] protected HealthBarComponent HealthBar { get; private set; }
    [field: SerializeField] protected Rigidbody2D rigidbody { get; private set; }
    [field: SerializeField] protected CircleCollider2D circleCollider { get; private set; }
    
    public EnemyData Data { get; private set; }

    protected float speed;

    public void Init()
    {
        Data = SOProps.Data;
        HealthBar.Init(Health);
        Health.Set(Data.health);
        Health.onDied.AddListener(Release);
        speed = Random.Range(Data.speedMin, Data.speedMax);
    }
    public void Kill()
    {
        Health.TakeDamage(float.MaxValue);
    }
    protected abstract void Update();
    protected abstract void Movement();
    protected abstract void Release();
}