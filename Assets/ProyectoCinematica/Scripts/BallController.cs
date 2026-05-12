using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public bool isLaunched;

    //Formula tiro parabolico:
    //1.En eje X: x = v0 * cos(alpha) * t.
    //2.En eje Y: y = y0 + v0 * sin(alpha) * t - (0.5 * g * t^2)

    private Vector3 initialVelocity;
    private Vector3 startPosition;
    private float launchTime;
    private float t;

    LauncherController launcher;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        //Referencia al script de trayectoria para mostrar la proyección
        FindAnyObjectByType<TrayectoriaBola>().ballController = this;
        startPosition = transform.position;
    }
	//Asigna el launcher encargado de generar y reiniciar la bola
    //Sirve para que la bola "sepa" que LauncherController la ha instanciado y asi pueda llamar a launcher.ResetBall() cuando la bolsa se destruye
	public void SetLauncher(LauncherController l) 

    {
        launcher = l;
    }
    private void Update()
    {
        //Si la bola no ha sido lanzada no se calcula el movimiento
        if (!isLaunched) return;

        t += Time.deltaTime;

        //Movimiento manual usando la formula parabólica
        if (rb.isKinematic)
        {
            Vector3 newPosition = CalculatePosition(t); 
            transform.position = newPosition;

            //Detecta colisiones durante el movimiento parabólico
            if (Physics.OverlapSphere(transform.position, 0.25f).Length > 1) 
            {
                //Activa fisicas reales al colisionar
                rb.isKinematic = false;
                rb.useGravity = true;
                //Calcula velocidad para mantener el movimiento continuo
                rb.linearVelocity = (CalculatePosition(t + 1f) - CalculatePosition(t));
            }
        }
    }

    public void Launch(Vector3 launchVelocity)
    {
        //Se desactivan fisicas para controlar el movimiento manualmente
        rb.isKinematic = true;

        initialVelocity = launchVelocity;
        launchTime = Time.time;

        isLaunched = true;
    }
    //Calcula posición usando las ecuaciones del tiro parabólico
    public Vector3 CalculatePosition(float time, Vector3 launchVelocity) 
    {
        float gravity = Physics.gravity.y;

        float x = startPosition.x + launchVelocity.x * time;
        float y = startPosition.y + launchVelocity.y * time + 0.5f * gravity * time * time;
        float z = startPosition.z + launchVelocity.z * time;


        return new Vector3(x, y, z);
    }
    //calcula la posición usando la velocidad inicial almacenada
    public Vector3 CalculatePosition(float time)
    {
        return CalculatePosition(time, initialVelocity);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        //Cuando la bola se cae de la mesa se destruye y se genera otra
        if (collision.gameObject.CompareTag("Ground"))
        {
            isLaunched = false;
            if (launcher != null)
            {
                launcher.ResetBall();
            }

            Destroy(gameObject);
        }

    }
}
