using UnityEngine;

[CreateAssetMenu(fileName = "Player_", menuName = "Data/Player")]
public class PlayerDataSO : ScriptableObject
{
    [field: SerializeField] public PlayerData Data { get; private set; }
}
