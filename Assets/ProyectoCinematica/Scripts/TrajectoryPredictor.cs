using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrayectoriaBola : MonoBehaviour
{
    public Transform puntoDisparo;
    public float fuerza = 10f;
    public int numPuntos = 30;
    public float tiempoEntrePuntos = 0.1f;

    public float fuerzaSalto = 2f;

    public Rigidbody bola;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (bola != null && bola.linearVelocity.magnitude > 0.1f)
        {
            lineRenderer.enabled = false;
            return;
        }

        lineRenderer.enabled = true;
        DibujarTrayectoria();
    }

    void DibujarTrayectoria()
    {

        lineRenderer.positionCount = numPuntos;

        Vector3 direccionXZ = puntoDisparo.forward;
        direccionXZ.y = 0;

        if (direccionXZ != Vector3.zero)
        {
            direccionXZ.Normalize();
        }

        Vector3 velocidadInicial = (direccionXZ * fuerza) + (Vector3.up * fuerzaSalto);

        float alturaMesa = puntoDisparo.position.y;

        for (int i = 0; i < numPuntos; i++)
        {
            float t = i * tiempoEntrePuntos;

      
            Vector3 posicion = puntoDisparo.position +
                               velocidadInicial * t +
                               0.5f * Physics.gravity * t * t;

           
            if (posicion.y < alturaMesa && i > 0)
            {
               
                posicion.y = alturaMesa;
                lineRenderer.SetPosition(i, posicion);

              
                lineRenderer.positionCount = i + 1;
                break; 
            }

            lineRenderer.SetPosition(i, posicion);
        }
    }
}