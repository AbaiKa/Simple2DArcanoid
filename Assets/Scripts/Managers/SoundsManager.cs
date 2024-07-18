using System.Collections;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private SoundsLibrary library;

    public void Init()
    {
        library.Init();
    }

    public void Play(string key)
    {
        AudioClip clip = library.GetSound(key);
        if (clip == null)
        {
            Debug.LogError($"Не нашли такой звук: {key}. Проверьте список звуков в SoundsLibrary");
            return;
        }

        StartCoroutine(PlayRoutine(clip));
    }

    private IEnumerator PlayRoutine(AudioClip clip)
    {
        AudioSource source = FactoryManager.Instance.AudioSourcesPool.Get();
        source.clip = clip;
        source.Play();

        yield return new WaitForSeconds(clip.length + 0.1f);

        FactoryManager.Instance.AudioSourcesPool.Return(source);
    }
}
