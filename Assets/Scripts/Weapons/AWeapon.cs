using UnityEngine;

public abstract class AWeapon : MonoBehaviour
{
    [SerializeField] private WeaponDataSO SOProps;

    public WeaponData Data { get; private set; }
    public bool CanShoot => 0 >= time;

    private float time;
    private float cooldown;
    private void Awake()
    {
        Data = SOProps.Data;
        cooldown = 1f / Data.shootsPerSecond;
        time = 0;
    }
    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, SOProps.Data.attackRange);
    }
    public abstract void Shoot(Vector2 direction);

    protected void ResetCooldown()
    {
        time = cooldown;
    }
}