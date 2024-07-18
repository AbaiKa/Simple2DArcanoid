using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_", menuName = "Data/Weapon")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public WeaponData Data { get; private set; }
}
