using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private AWeapon weapon;

    private readonly float searchTime = 0.8f;
    private Transform currentTarget;
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        if(currentTarget != null)
        {
            if (weapon.CanShoot)
            {
                Vector2 dir = (currentTarget.position - weapon.transform.position).normalized;
                weapon.Shoot(dir);
            }
        }
    }
    public void Init()
    {
        StartCoroutine(SearchNearestTargetRoutine());
    }

    private IEnumerator SearchNearestTargetRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(searchTime);
            currentTarget = GetNearestTarget();
        }
    }
    private Transform GetNearestTarget()
    {
        Vector2 position = weapon.transform.position;
        float range = weapon.Data.attackRange;
        int targetMask = weapon.Data.targetMask.value;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(position, range, targetMask);

        Transform nearestTarget = null;
        float minDistance = float.MaxValue;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            Vector3 targetPos = hitColliders[i].transform.position;
            float distance = Vector2.Distance(position, targetPos);

            if (minDistance > distance)
            {
                minDistance = distance;
                nearestTarget = hitColliders[i].transform;
            }
        }

        return nearestTarget;
    }
}