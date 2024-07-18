using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemiesManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private EnemyWaveDataSO SOProps;

    /// <summary>
    /// <para>1) Текущее количество убитых врагов</para>
    /// <para>2) Максимальное количество врагов</para>
    /// </summary>
    public UnityEvent<int, int> onEnemyDie;
    public UnityEvent onWaveFinish;
    private EnemyWaveData Data => SOProps.Data;

    private GameManager manager;
    private int wavesCount;
    private int diedsCount;
    public void Init(GameManager manager)
    {
        this.manager = manager;
        StartCoroutine(StartWaveRoutine());
    }
    public void DeInit()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartWaveRoutine()
    {
        yield return new WaitForSeconds(Data.waveStartingTime);

        wavesCount = Random.Range(Data.waveEndMin, Data.waveEndMax);
        int waves = wavesCount;
        diedsCount = 0;

        while(waves > 0)
        {
            float spawnTime = Random.Range(Data.spawnTimeMin, Data.spawnTimeMax);
            yield return new WaitForSeconds(spawnTime);

            SimpleEnemy enemy = FactoryManager.Instance.simpleEnemyFactory.Create();
            enemy.Health.onTakeDamage.AddListener(OnEnemyTakeDamage);
            enemy.Health.onDied.AddListener(OnEnemyDie);
            waves--;
        }

        onWaveFinish?.Invoke();
    }
    private void OnEnemyTakeDamage(float damage)
    {
        manager.SoundsManager.Play("EnemyTakeDamage");
    }
    private void OnEnemyDie()
    {
        diedsCount++;
        onEnemyDie?.Invoke(diedsCount, wavesCount);
    }
}
