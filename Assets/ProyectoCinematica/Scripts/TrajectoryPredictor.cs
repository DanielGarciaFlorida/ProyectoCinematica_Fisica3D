using UnityEngine;

// Asegura que el objeto tenga un LineRenderer para poder dibujar la línea

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
    public BallController ballController;
    public LauncherController launchController;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Controla la visibilidad de la trayectoria según si la bola ha sido lanzada o no
    void Update()
    {
        if (ballController == null) return;

        if(ballController.isLaunched)
        {
            lineRenderer.enabled = false;
            return;
        }
        lineRenderer.enabled = true;
        DibujarTrayectoria();
    }

    // Calcula y dibuja los puntos de la parábola proyectada antes del lanzamiento
    void DibujarTrayectoria()
    {
        lineRenderer.positionCount = 0;
        if (ballController == null) return;
        float t = 0;
        while (t < 5)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, ballController.CalculatePosition(t, launchController.GetLaunchVelocity()));
            t += 0.1f;
        }
    }

}