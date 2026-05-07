using UnityEngine;

public class AgujerosTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallCounter.Instance.BallEnteredHole();
        }
    }
}