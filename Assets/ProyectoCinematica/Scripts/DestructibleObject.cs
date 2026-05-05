using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            UIManager.Instance.GameOver();
        }
    }
}