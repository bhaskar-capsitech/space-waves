using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    public GameObject[] obstacles;
    public float minX = 25f;
    public float maxX = 30f;
    public float yPos = 2.5f;
    public float zPos = 4.5f;
    public float spawnInterval = 2f;


    private PlayerJump playerJumpScript;

    void Start()
    {

        playerJumpScript = GameObject.Find("Player").GetComponent<PlayerJump>();
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
        
    }

    void SpawnObstacle()
    {

        if (playerJumpScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
            return;
        }

        int index = Random.Range(0, obstacles.Length);
        GameObject obstacleToSpawn = obstacles[index];
       
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, yPos, zPos);
        
        Instantiate(obstacleToSpawn, spawnPosition, obstacleToSpawn.transform.rotation);
    }
}
