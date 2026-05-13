using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Implementación de Singleton para acceso global desde cualquier parte del juego
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Lógica para manejar eventos de finalización de nivel
    private void WinLevel()
    {
        Debug.Log("You win!");
    }
    // Funciones para gestionar el flujo de escenas: recargar nivel actual o ir al inicio
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
