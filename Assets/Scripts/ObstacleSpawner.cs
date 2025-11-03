using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // List of obstacles to spawn
    public GameObject[] obstacles;

    // Spawn position constraints
    public float minX = -5.0f;
    public float maxX = 12.5f;
    public float yPos = 0f;
    public float zPos = 4.5f;

    // Spawn interval
    public float spawnInterval = 2f;

    void Start()
    {
        // Start spawning repeatedly
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Pick a random obstacle from the list
        int index = Random.Range(0, obstacles.Length);
        GameObject obstacleToSpawn = obstacles[index];

        // Randomize x position
        float randomX = Random.Range(minX, maxX);

        // Set spawn position
        Vector3 spawnPosition = new Vector3(randomX, yPos, zPos);

        // Instantiate the obstacle
        Instantiate(obstacleToSpawn, spawnPosition, obstacleToSpawn.transform.rotation);
    }
}
