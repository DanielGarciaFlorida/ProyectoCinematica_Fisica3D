using UnityEngine;
using UnityEngine.InputSystem;

public class LauncherController : MonoBehaviour
{
    public BallController ballPrefab;
    public Transform spawnPoint;

    public float force = 10f;
    public float angle = 45f;

    private PlayerInputActions inputActions;
    private BallController currentBall;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Gameplay.Shoot.performed += OnShoot;
    }

    void OnDisable()
    {
        inputActions.Gameplay.Shoot.performed -= OnShoot;
        inputActions.Disable();
    }
    void Start()
    {
        SpawnBall();
    }

    void SpawnBall()
    {
        currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }

    void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }

    void Shoot()
    {
        if (currentBall == null) return;

        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 direction = (mousePos - spawnPoint.position).normalized;
        Vector3 launchVelocity = CalculatedLaunchVelocity(direction);

        currentBall.Launch(launchVelocity);

        currentBall = null;
    }

    Vector3 CalculatedLaunchVelocity(Vector3 direction)
    {
        float angleInRadians = angle * Mathf.Deg2Rad;

        Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z).normalized;

        float vx = force * Mathf.Cos(angleInRadians);
        float vy = force * Mathf.Sin(angleInRadians);

        Vector3 launchVelocity = horizontalDirection * vx;
        launchVelocity.y = vy;

        return launchVelocity;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector2 mousePos = inputActions.Gameplay.Position.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        float planeY = spawnPoint.position.y;

        float distance = (planeY - ray.origin.y) / ray.direction.y;

        return ray.origin + ray.direction * distance;

        Debug.DrawLine(spawnPoint.position, mousePos, Color.red);
        // Plane groundPlane = new Plane(Vector3.up, spawnPoint.position);

        /* if(groundPlane.Raycast(ray, out float distance))
         {
             return ray.GetPoint(distance);
         }

         return spawnPoint.position; */
    }

    public void ResetBall()
    {
        if (currentBall != null)
        {
            Destroy(currentBall.gameObject);
        }
        SpawnBall();
    }

    //Necesario para calcular la trayectoria
    public Vector3 GetLaunchVelocity()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 direction = (mousePos - spawnPoint.position).normalized;
        return CalculatedLaunchVelocity(direction);
    }
}
