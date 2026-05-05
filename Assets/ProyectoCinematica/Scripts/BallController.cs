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

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!isLaunched) return;


       
    }

    public void Launch(Vector3 velocity)
    {
        rb.isKinematic = false;

        initialVelocity = velocity;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            Debug.Log("Goal);
            //llamar al GameManager
        }
        
    }
}
