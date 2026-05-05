using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject gameOverPanel;

    private void Awake()
    {
        Instance = this;

        // 🔴 IMPORTANTE: ocultar al empezar
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        GameManager.Instance.RestartLevel();
    }
}