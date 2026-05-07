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
    public BallController ballController;
    public LauncherController launchController;

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