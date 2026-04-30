using UnityEngine;

public enum GameState
{
    Aiming,
    Launched,
    Win,
    Lose
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState currentState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }
    
    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("Estado: " + newState);
    }

    public void OnHitTarget()
    {
        if (currentState != GameState.Launched) return;

        SetState(GameState.Win);
    }

    public void OnMiss()
    {
        if (currentState != GameState.Launched) return;

        SetState(GameState.Lose);
    }

    /*public void RestartLevel()
    {

    }*/
}
