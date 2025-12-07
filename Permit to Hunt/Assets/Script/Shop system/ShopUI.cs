using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject shopPanel;
    bool isOpen = false;

    void Start()
    {
        shopPanel.SetActive(false);
    }

    public void ToggleShop()
    {
        isOpen = !isOpen;

        shopPanel.SetActive(isOpen);

        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
