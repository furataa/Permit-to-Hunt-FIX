using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Gun currentGun;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentGun.Shoot();
        }
    }
}
