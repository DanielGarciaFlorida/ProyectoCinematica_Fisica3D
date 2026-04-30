using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 velocity)
    {
        rb.isKinematic = false;
        rb.linearVelocity = velocity;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("HIT");
            //llamar al GameManager
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("MISS");
            //llamar al GameManager
        }
    }
}
