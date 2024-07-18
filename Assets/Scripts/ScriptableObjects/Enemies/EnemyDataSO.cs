using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_", menuName = "Data/Enemy")]
public class EnemyDataSO : ScriptableObject
{
    [field: SerializeField] public EnemyData Data { get; private set; } 
}
