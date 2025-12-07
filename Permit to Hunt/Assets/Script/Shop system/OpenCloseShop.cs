using UnityEngine;
using UnityEngine.SceneManagement; 

public class OpenCloseShop : MonoBehaviour
{
    public GameObject shopPanel; 
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseAndOpenShop();
            }
        }
    }

    public void PauseAndOpenShop()
    {
        Time.timeScale = 0f;
        shopPanel.SetActive(true); 
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        shopPanel.SetActive(false);
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}