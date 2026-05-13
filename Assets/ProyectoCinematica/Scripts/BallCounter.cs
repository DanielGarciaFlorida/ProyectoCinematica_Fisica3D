using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCounter : MonoBehaviour
{
    // Singleton para acceso global y variables de configuración de UI y juego
    public static BallCounter Instance;

    [Header("UI")]
    public TextMeshProUGUI counterText;
    public GameObject victoryCanvas;

    [Header("Configuración")]
    public int totalBalls = 15;

    private int ballsInside = 0;

    // Inicialización del Singleton y estado inicial de la UI
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
        victoryCanvas.SetActive(false);
    }

    // Lógica principal: registra cada bola, actualiza la UI y verifica la condición de victoria
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
    // Refresca el texto en pantalla con el conteo actual
    void UpdateUI()
    {
        counterText.text = ballsInside + "/" + totalBalls;
    }

    // Gestiona la transición entre niveles o reinicia el juego al finalizar
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