using UnityEngine;

public class AgujerosTrigger : MonoBehaviour
{
    // Se ejecuta automáticamente al entrar en el área del trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró es la bola mediante su etiqueta
        if (other.CompareTag("Ball"))
        {
            // Notifica al gestor de puntuación que una bola ha caído en el agujero
            BallCounter.Instance.BallEnteredHole();
        }
    }
}