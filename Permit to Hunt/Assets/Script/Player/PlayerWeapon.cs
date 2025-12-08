using UnityEngine;
using System.Collections.Generic;

public class PlayerWeaponManager : MonoBehaviour
{
    // Pola Singleton untuk akses cepat dari ShopUI
    public static PlayerWeaponManager Instance { get; private set; }

    [Header("Inventaris")]
    // Daftar semua senjata yang dimiliki pemain
    public List<GunItem> ownedGuns = new List<GunItem>(); 
    
    [Header("Komponen Fisik")]
    // Transform tempat model senjata akan di-instantiate (di tangan pemain)
    public Transform weaponHolder; 
    // Referensi ke WeaponController Anda
    public WeaponController weaponController; 

    private GameObject currentWeaponModel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Jika sudah ada, hancurkan yang ini (untuk menghindari duplikasi Singleton)
            Destroy(gameObject); 
        }
    }

    // Dipanggil dari ShopUI setelah pembelian berhasil
    public void AddGunToInventory(GunItem gun)
    {
        if (!ownedGuns.Contains(gun))
        {
            ownedGuns.Add(gun);
            // Opsional: Otomatis equip senjata pertama yang didapatkan
            if (ownedGuns.Count == 1)
            {
                EquipGun(gun);
            }
        }
    }

    // Dipanggil untuk mengganti senjata yang sedang dipakai
    public void EquipGun(GunItem gunToEquip)
    {
        if (!ownedGuns.Contains(gunToEquip))
        {
            Debug.LogError($"Cannot equip {gunToEquip.gunName}, not owned!");
            return;
        }

        // 1. Hancurkan model senjata lama (jika ada)
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }

        // 2. Instantiate model senjata baru di holder
        currentWeaponModel = Instantiate(gunToEquip.gunPrefab, weaponHolder);
        
        // 3. Update data di WeaponController
        // Asumsi: Prefab senjata memiliki komponen Gun/Weapon yang sebenarnya
        Gun newGunComponent = currentWeaponModel.GetComponent<Gun>(); 
        
        if (weaponController != null && newGunComponent != null)
        {
            weaponController.currentGun = newGunComponent; 
        }
        
        Debug.Log($"Senjata diganti ke: {gunToEquip.gunName}");
    }
}