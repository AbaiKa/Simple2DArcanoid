using UnityEngine;

[CreateAssetMenu(fileName = "Sound_", menuName = "Data/Sound")]
public class SoundDataSO : ScriptableObject
{
    [field: SerializeField] public SoundData Data { get; set; }    
}
