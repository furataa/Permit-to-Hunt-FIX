using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject shopPanel;
    bool isOpen = false; // Pastikan defaultnya false

    void Start()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void ToggleShop()
    {
        
        isOpen = !isOpen; 
        shopPanel.SetActive(isOpen);

        if (isOpen)
        {
          
            Time.timeScale = 0f; 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Game Paused: Shop Opened");
        }
        else
        {
          
            Time.timeScale = 1f; 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("Game Resumed: Shop Closed");
        }
    }

    public void PurchaseGun(GunItem gunToBuy) 
    {
        // Pastikan PlayerStats.Instance dan PlayerWeaponManager.Instance siap
        if (PlayerStats.Instance == null || PlayerWeaponManager.Instance == null) return;

        if (PlayerStats.Instance.TrySpendCoins(gunToBuy.price))
        {
            // Berhasil: Tambahkan senjata dan equip
            PlayerWeaponManager.Instance.AddGunToInventory(gunToBuy);
            PlayerWeaponManager.Instance.EquipGun(gunToBuy);
            Debug.Log($"Successfully purchased: {gunToBuy.gunName}");
        }
        else
        {
            Debug.Log("Purchase failed: Not enough coins.");
        }
    }
}
