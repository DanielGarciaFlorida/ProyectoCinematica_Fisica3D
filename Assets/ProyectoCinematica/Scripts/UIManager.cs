using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton para permitir acceso sencillo a la gestión de UI desde otros scripts
    public static UIManager Instance;

    // Referencia al panel de fin de juego que se activará/desactivará
    public GameObject gameOverPanel;

    // Método conectado a un botón para reiniciar el nivel a través del GameManager
    public void RestartButton()
    {
        GameManager.Instance.RestartLevel();
    }
}