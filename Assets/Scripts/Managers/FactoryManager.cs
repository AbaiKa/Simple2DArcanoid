using System;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static FactoryManager Instance { get; private set; }

    [SerializeField] public SimpleEnemyFactory simpleEnemyFactory;

    [SerializeField] private SimpleBulletFactory simpleBulletFactory;
    [SerializeField] private AudioSourceFactory audioSourceFactory;

    public APool<SimpleBullet> SimpleBulletPool { get; private set; }
    public APool<AudioSource> AudioSourcesPool { get; private set; }

    public void Init()
    {
        Instance = this;

        SimpleBulletPool = new APool<SimpleBullet>(simpleBulletFactory);
        AudioSourcesPool = new APool<AudioSource>(audioSourceFactory);
    }


    #region Factories
    [Serializable]
    public class AudioSourceFactory : AFactory<AudioSource>
    {
        public override AudioSource Create()
        {
            AudioSource item = Instantiate(prefab, container);
            return item;
        }
    }
    [Serializable]
    public class SimpleBulletFactory : AFactory<SimpleBullet>
    {
        public override SimpleBullet Create()
        {
            SimpleBullet item = Instantiate(prefab, container);
            return item;
        }
    }
    [Serializable]
    public class SimpleEnemyFactory : AFactory<SimpleEnemy>
    {
        [SerializeField] private Transform[] spawnPoints;
        public override SimpleEnemy Create()
        {
            var point = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            var item = Instantiate(prefab, point.position, point.rotation);
            item.transform.SetParent(container);
            item.Init();
            return item;
        }
    }
    #endregion
}
