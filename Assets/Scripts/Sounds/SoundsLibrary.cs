using System.Collections.Generic;
using UnityEngine;

public class SoundsLibrary : MonoBehaviour
{
    [SerializeField] private SoundDataSO SOProps;

    private SoundItem[] sounds;
    private Dictionary<string, AudioClip> library = new Dictionary<string, AudioClip>();

    public void Init()
    {
        sounds = SOProps.Data.Sounds;
        for (int i = 0; i < sounds.Length; i++)
        {
            if (library.ContainsKey(sounds[i].key) == false)
            {
                library.Add(sounds[i].key, sounds[i].clip);
            }
        }
    }
    public AudioClip GetSound(string key)
    {
        if (library.ContainsKey(key))
        {
            return library[key];
        }

        return null;
    }
}
