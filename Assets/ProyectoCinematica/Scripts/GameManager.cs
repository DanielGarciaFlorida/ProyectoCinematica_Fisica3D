using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void WinLevel()
    {
        Debug.Log("You win!");
    }

   /* public void RestartLevel()
    {
    }
   */
}
