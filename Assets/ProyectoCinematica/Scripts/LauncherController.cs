using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public ProjectileController projectilePrefab;
    public Transform spawnPoint;
    public float launchForce = 10f;

    public void Launch()
    {
        ProjectileController proj = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

        Vector3 direction = transform.forward;
        proj.Launch(direction * launchForce);
    }
}
