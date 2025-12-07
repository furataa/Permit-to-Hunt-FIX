using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuManager : MonoBehaviour
{
    
    public void StartGame()
    {
        
        SceneManager.LoadScene("Map Utama"); 
    }

    public void QuitGame()
    {
        
        Application.Quit();

      
    }

}
