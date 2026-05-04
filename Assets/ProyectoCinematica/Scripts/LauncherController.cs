using UnityEngine;
using UnityEngine.InputSystem;

public class LauncherController : MonoBehaviour
{
    public BallController projectilePrefab;
    public Transform spawnPoint;
    public float launchForce = 10f;

    private PlayerInputActions input;
    private BallController currentProjectile;

    private void Awake()
    {
        input = new PlayerInputActions();
    }
    void OnEnable()
    {
        input.Enable();
        input.Gameplay.Shoot.performed += OnShoot;
    }

    void OnDisable()
    {
        input.Gameplay.Shoot.performed -= OnShoot;
        input.Disable();
    }
    private void Start()
    {
        SpawnProjectile();
    }

    void SpawnProjectile()
    {

        currentProjectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();
        rb.isKinematic = true; //para que no caiga hasta disparar
    }

    void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }

    void Shoot()
    {
        if (currentProjectile == null) return;

        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        Vector3 direction = transform.forward;
        currentProjectile.Launch(direction * launchForce);

        currentProjectile = null;

        //SpawnProjectile();
        //GameManager.Instantiate.SetState(GameState.Launched);
    }
}
