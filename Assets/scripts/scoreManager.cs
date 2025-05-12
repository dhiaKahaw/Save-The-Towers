using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 
    public int score = 0; // Player's score
    public TextMeshProUGUI scoreText; // UI Text for displaying the score

    void Awake()
    {
        // Ensure only one ScoreManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points; // Increase score
        UpdateScoreUI();
        Debug.Log("Score Updated: " + score); // Debug Log
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
