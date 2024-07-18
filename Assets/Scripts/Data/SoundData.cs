using System;
using UnityEngine;

[Serializable]
public class SoundData
{
    [field: SerializeField] public SoundItem[] Sounds { get; private set; }
}
[Serializable]
public struct SoundItem
{
    public string key;
    public AudioClip clip;
}
