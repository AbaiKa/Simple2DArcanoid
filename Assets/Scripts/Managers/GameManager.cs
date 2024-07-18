using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public UIManager UIManager {  get; private set; }
    [field: SerializeField] public PlayerController PlayerController { get; private set; }
    [field: SerializeField] public PlayerHealth PlayerHealth { get; private set; }
    [field: SerializeField] public EnemiesManager EnemiesManager { get; private set; }
    [field: SerializeField] public FactoryManager FactoryManager { get; private set; }
    [field: SerializeField] public SceneLoadingManager SceneLoadingManager { get; private set; }
    [field: SerializeField] public SoundsManager SoundsManager { get; private set; }

    [HideInInspector] public UnityEvent<bool> onGameOver;

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        Registr();
        FactoryManager.Init();
        UIManager.Init(this);
        EnemiesManager.Init(this);
        SoundsManager.Init();
        PlayerController.Init(this);
    }
    private void Registr()
    {
        PlayerHealth.Health.onDied.AddListener(() => { 
            onGameOver?.Invoke(false);
            onGameOver.RemoveAllListeners();
        });
        PlayerHealth.Health.onTakeDamage.AddListener((c) => { SoundsManager.Play("PlayerTakeDamage"); });

        EnemiesManager.onEnemyDie.AddListener(OnEnemyDie);
        onGameOver.AddListener(OnGameOver);
    }
    private void OnGameOver(bool win)
    {
        EnemiesManager.DeInit();
        PlayerController.DeInit();

        string key = win ? "WinGame" : "LoseGame";
        SoundsManager.Play(key);
    }
    private void OnEnemyDie(int current, int max)
    {
        if(current == max)
        {
            onGameOver?.Invoke(current > max - PlayerHealth.Health.StartHealth);
            onGameOver.RemoveAllListeners();
            SoundsManager.Play("EnemyDied");
        }
    }
}
