using TMPro;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    public static BallCounter Instance;

    [Header("UI")]
    public TextMeshProUGUI counterText;
    public GameObject victoryCanvas;

    [Header("Configuración")]
    public int totalBalls = 15;

    private int ballsInside = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
        victoryCanvas.SetActive(false);
    }

    public void BallEnteredHole()
    {
        ballsInside++;

        UpdateUI();

        if (ballsInside >= totalBalls)
        {
            victoryCanvas.SetActive(true);
        }
    }

    void UpdateUI()
    {
        counterText.text = ballsInside + "/" + totalBalls;
    }
}