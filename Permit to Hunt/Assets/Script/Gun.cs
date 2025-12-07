using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 25;
    public Camera cam;
    public AudioSource shootSound;
    public ParticleSystem muzzleFlash; // efek api

    public void Shoot()
    {
        // Efek api
        muzzleFlash.Play();

        // Suara
        shootSound.Play();

        // Raycast
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
