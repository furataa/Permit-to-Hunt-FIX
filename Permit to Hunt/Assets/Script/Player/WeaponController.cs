using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Gun currentGun;

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return; 
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            currentGun.Shoot();
        }

        
    }   
}
    



