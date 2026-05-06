using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject gameOverPanel;

 

    public void RestartButton()
    {
       
        GameManager.Instance.RestartLevel();
    }
}