using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    public int coins = 0;

    // Event untuk memberi tahu UI kalau coin berubah
    public event Action<int> OnCoinChanged;

    public void AddCoins(int amount)
    {
        coins += amount;

        if (OnCoinChanged != null)
            OnCoinChanged(coins);
    }

    public bool TrySpendCoins(int amount)
    {
        if (amount <= 0) return false;
        
        if (coins >= amount)
        {
            coins -= amount;
            
            // Panggil Event untuk update UI
            OnCoinChanged?.Invoke(coins);
            
            Debug.Log($"Koin berkurang {amount}. Sisa: {coins}");
            return true; // Berhasil
        }
        else
        {
            Debug.Log("Pembelian gagal: Koin tidak cukup.");
            return false; // Gagal
        }
    }
}
