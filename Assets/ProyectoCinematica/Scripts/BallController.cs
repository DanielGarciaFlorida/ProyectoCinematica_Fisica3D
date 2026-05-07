using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    private bool isLaunched = false;

    //Formula tiro parabolico.
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
    }
    public void SetLauncher(LauncherController l)
    {
        launcher = l;
    }
    private void Update()
    {
        if (!isLaunched) return;

        t += Time.deltaTime;


       if (rb.isKinematic)
        {
            Vector3 newPosition = CalculatePosition(t);
            transform.position = newPosition;

            if (Physics.OverlapSphere(transform.position, 0.25f).Length > 1)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.linearVelocity = (CalculatePosition(t + 1f) - CalculatePosition(t));
            }
        }
    }

    public void Launch(Vector3 launchVelocity)
    {

        rb.isKinematic = true;

        initialVelocity = launchVelocity;
        startPosition = transform.position;
        launchTime = Time.time;

        isLaunched = true;
    }

    Vector3 CalculatePosition(float time)
    {
        float gravity = Physics.gravity.y;

        float x = startPosition.x + initialVelocity.x * time;
        float y = startPosition.y + initialVelocity.y * time + 0.5f * gravity * time * time;
        float z = startPosition.z + initialVelocity.z * time;


        return new Vector3(x, y, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
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


    /* Hasta que no metamos el modelo 3D de la mesa no podremos probar esta parte
     void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Hole"))
         {
             Debug.Log("Goal");
             //llamar al GameManager
         }

     }
    */
}
