using UnityEngine;

public class ShopToggleKey : MonoBehaviour
{
    public ShopUI shopUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            shopUI.ToggleShop();
        }
    }
}
