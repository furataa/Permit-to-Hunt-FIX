using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public int coins = 0;

    // Event untuk memberi tahu UI kalau coin berubah
    public event Action<int> OnCoinChanged;

    public void AddCoins(int amount)
    {
        coins += amount;

        if (OnCoinChanged != null)
            OnCoinChanged(coins);
    }
}
