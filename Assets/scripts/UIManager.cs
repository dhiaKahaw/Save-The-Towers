using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Required for TextMeshProUGUI

public class UIManager : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject gameplayUI;
    public GameObject gameOverUI;

    public TextMeshProUGUI finalScoreText; // Reference to the final score text

    void Start()
    {
        ShowStartMenu();
        AudioManager.instance.PlayBackgroundMusic(); // Play background music
    }

    public void ShowStartMenu()
    {
        startMenuUI.SetActive(true);
        gameplayUI.SetActive(false);
        gameOverUI.SetActive(false);
        Time.timeScale = 0; // Pause the game at the start
    }

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
        gameOverUI.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }

    public void GameOver()
    {
        startMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0; // Pause game on Game Over

        // Update the final score text
        UpdateFinalScore();
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the scene


        Debug.Log("Game Restarted!");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }

    private void UpdateFinalScore()
    {
        if (finalScoreText != null && ScoreManager.instance != null)
        {
            // Display the final score
            finalScoreText.text = "Final Score: " + ScoreManager.instance.score;
        }
        else
        {
            Debug.LogError("Final score text or ScoreManager instance is null!");
        }
    }
}