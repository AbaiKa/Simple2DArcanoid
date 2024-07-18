using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Counter")]
    [SerializeField] private TextMeshProUGUI counterText;
   
    [Header("GameOver")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Button winRestartButton;
    [SerializeField] private Button loseRestartButton;


    private GameManager gameManager;

    public void Init(GameManager gameManager)
    {
        gameManager.onGameOver.AddListener(ShowGameOverPanel);
        gameManager.EnemiesManager.onEnemyDie.AddListener(UpdateCounter);

        winRestartButton.onClick.AddListener(gameManager.SceneLoadingManager.ReloadCurrentScene);
        loseRestartButton.onClick.AddListener(gameManager.SceneLoadingManager.ReloadCurrentScene);

        gameOverPanel.SetActive(false);
    }
    public void DeInit()
    {
        gameOverPanel.SetActive(false);
        UpdateCounter(0, 0);
    }
    private void UpdateCounter(int current, int max)
    {
        counterText.text = $"{current}/{max}";
    }
    private void ShowGameOverPanel(bool win)
    {
        gameOverPanel.SetActive(true);
        losePanel.SetActive(!win);
        winPanel.SetActive(win);
    }
}
