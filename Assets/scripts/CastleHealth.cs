using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over! Castle has been destroyed!");

        // Call UIManager to handle Game Over screen
        FindObjectOfType<UIManager>().GameOver();

        gameObject.SetActive(false);
        // Disable the castle (instead of destroying it)
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        gameObject.SetActive(true); 
    }
}
