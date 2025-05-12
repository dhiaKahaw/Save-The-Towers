using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float initialMinSpawnTime = 3f; // Initial minimum time between spawns
    public float initialMaxSpawnTime = 5f; // Initial maximum time between spawns
    public float minSpawnTimeLimit = 0.5f; // Minimum possible spawn time (to prevent it from becoming too fast)
    public float spawnTimeAcceleration = 0.1f; // How much faster the spawn rate becomes over time
    public int maxEnemies = 10; // Maximum number of enemies to spawn
    public float initialDelay = 1f; // Delay before the first spawn

    private float currentMinSpawnTime;
    private float currentMaxSpawnTime;
    private int currentEnemies = 0;

    void Start()
    {
        // Initialize spawn times
        currentMinSpawnTime = initialMinSpawnTime;
        currentMaxSpawnTime = initialMaxSpawnTime;

        // Start the spawning coroutine
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    IEnumerator SpawnEnemiesWithDelay()
    {
        // Wait for the initial delay before starting to spawn enemies
        yield return new WaitForSeconds(initialDelay);

        // Continue spawning until the maximum number of enemies is reached
        while (currentEnemies < maxEnemies)
        {
            SpawnEnemy(); // Spawn an enemy

            // Calculate a random spawn interval based on the current min and max spawn times
            float randomInterval = Random.Range(currentMinSpawnTime, currentMaxSpawnTime);
            yield return new WaitForSeconds(randomInterval);

            // Accelerate the spawn rate over time
            AccelerateSpawnRate();
        }
    }

    void SpawnEnemy()
    {
        if (currentEnemies < maxEnemies)
        {
            // Instantiate the enemy at the spawner's position and rotation
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            currentEnemies++;
            Debug.Log("Enemy spawned. Total enemies: " + currentEnemies);
        }
    }

    void AccelerateSpawnRate()
    {
        // Reduce the spawn time intervals to make enemies spawn faster
        currentMinSpawnTime = Mathf.Max(currentMinSpawnTime - spawnTimeAcceleration, minSpawnTimeLimit);
        currentMaxSpawnTime = Mathf.Max(currentMaxSpawnTime - spawnTimeAcceleration, minSpawnTimeLimit);

        Debug.Log($"Spawn rate accelerated. Min: {currentMinSpawnTime}, Max: {currentMaxSpawnTime}");
    }
}