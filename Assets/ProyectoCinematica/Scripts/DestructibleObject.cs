using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
   public GameObject canvas;

    private void Awake()
    {
        canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
           canvas.SetActive(true);
        }
    }
}