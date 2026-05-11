using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            PasarSiguienteNivel();
        }
    }

    void UpdateUI()
    {
        counterText.text = ballsInside + "/" + totalBalls;
    }

    public void PasarSiguienteNivel()
    {
        
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        if (indiceEscenaActual == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(indiceEscenaActual + 1);
        }
    }
}