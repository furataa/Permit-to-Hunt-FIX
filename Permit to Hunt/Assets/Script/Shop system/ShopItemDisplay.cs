using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ShopItemDisplay : MonoBehaviour
{
    // Hubungkan komponen UI ini di Inspector pada template item Anda
    public Image iconImage;
    public TMP_Text nameText;
    public TMP_Text priceText;
    public Button buyButton; 

    private GunItem linkedGunItem; // Menyimpan referensi data item ini

    // Dipanggil oleh ShopUI.cs untuk mengatur tampilan item
    public void Setup(GunItem gunData, ShopUI shopUI)
    {
        linkedGunItem = gunData;
        
        // 1. Tampilkan Data
        iconImage.sprite = gunData.icon;
        nameText.text = gunData.gunName;
        priceText.text = gunData.price.ToString() + " Koin";
        
        // 2. Hubungkan Tombol Beli secara dinamis
        buyButton.onClick.RemoveAllListeners(); // Hapus event lama
        
        // Tambahkan Listener: Ketika tombol diklik, panggil ShopUI.PurchaseGun
        // dan kirim data senjata ini (gunData) sebagai parameter.
        buyButton.onClick.AddListener(() => shopUI.PurchaseGun(gunData));
    }
}