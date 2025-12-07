using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public int coinReward = 10; // coin yang diberikan saat mati

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Tambahkan coin ke player
        PlayerStats player = FindObjectOfType<PlayerStats>();
        if (player != null)
        {
            player.AddCoins(coinReward);
        }

        Destroy(gameObject);
    }
}
