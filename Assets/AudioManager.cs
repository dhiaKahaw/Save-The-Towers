using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton pattern

    public AudioSource backgroundMusic;
    public AudioSource enemyReachedCastleSound;
    public AudioSource enemyKilledSound;

    void Awake()
    {
        // Ensure only one AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate AudioManager
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    public void PlayEnemyReachedCastleSound()
    {
        if (enemyReachedCastleSound != null)
        {
            enemyReachedCastleSound.Play();
        }
    }

    public void PlayEnemyKilledSound()
    {
        if (enemyKilledSound != null)
        {
            enemyKilledSound.Play();
        }
    }
}