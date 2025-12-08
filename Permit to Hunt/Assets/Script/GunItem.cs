using UnityEngine;

public class GunItem : ScriptableObject
{
    public string gunName = "Pistol";
    public int price = 100;
    
    [Header("Shop Display")]
    public Sprite icon; 
    
    [Header("Model & Stats")]
    // Prefab model 3D senjata yang akan di-instantiate
    public GameObject gunPrefab; 
    
   
}
