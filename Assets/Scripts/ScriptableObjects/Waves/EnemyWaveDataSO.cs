using UnityEngine;

[CreateAssetMenu(fileName = "Wave_", menuName = "Data/EnemyWave")]
public class EnemyWaveDataSO : ScriptableObject
{
    [field: SerializeField] public EnemyWaveData Data { get; private set; }
}
