using UnityEngine;
using UnityEngine.InputSystem;

public class LauncherController : MonoBehaviour
{
    public BallController ballPrefab;
    public Transform spawnPoint;

    private float force = 5.5f;
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
        currentBall.SetLauncher(this);
    }

    void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("CLICK DETECTADO");
        Shoot();
    }

    void Shoot()
    {
        if (currentBall == null) return;

        Vector3 mousePos = GetMouseWorldPosition(); //1. Obtener la posición del mouse en el mundo

        //2. Calcular la dirección desde el spawnPoint hacia la posición del mouse
        Vector3 direction = mousePos - spawnPoint.position;
       
        direction.y = 0; // Ignorar la componente vertical para calcular la dirección horizontal
        force = direction.magnitude * 1.2f;
        direction.Normalize();

        Debug.DrawLine(spawnPoint.position, mousePos, Color.red, 2f);
        Debug.Log("Direccion: " + direction);

        //3.Calcular velocidad parabólica
        Vector3 launchVelocity = CalculatedLaunchVelocity(direction);

        currentBall.Launch(launchVelocity); //4. Lanzar la bola

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
        Vector2 mouseScreenPosition = inputActions.Gameplay.Position.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        float planeY = spawnPoint.position.y;

        float distance = (planeY - ray.origin.y) / ray.direction.y;

        return ray.origin + ray.direction * distance;

        //Vector3 worldPosition = ray.origin + ray.direction * distance;

        //Debug.DrawLine(spawnPoint.position, worldPosition, Color.red);

        //return worldPosition;
        // Plane groundPlane = new Plane(Vector3.up, spawnPoint.position);

        /* if(groundPlane.Raycast(ray, out float distance))
         {
             return ray.GetPoint(distance);
         }

         return spawnPoint.position; */
    }

    public void ResetBall()
    {
        SpawnBall();
    }

    //Necesario para calcular la trayectoria
    public Vector3 GetLaunchVelocity()
    {
        Vector3 mousePos = GetMouseWorldPosition();

        Vector3 direction = mousePos - spawnPoint.position;
        direction.y = 0;
        direction.Normalize();
        return CalculatedLaunchVelocity(direction);
    }
}
