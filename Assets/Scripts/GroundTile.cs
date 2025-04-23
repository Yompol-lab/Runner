using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    [Header("Prefabs")]
    public GameObject obtaclePrefab;
    public GameObject powerUpPrefab;

    [Header("Power-Up Settings")]
    public float powerUpSpawnChance = 0.5f; 

    [System.Obsolete]
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacleAndPowerUp();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    void SpawnObstacleAndPowerUp()
    {
        
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform obstacleSpawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obtaclePrefab, obstacleSpawnPoint.position, Quaternion.identity, transform);

        
        if (Random.value < powerUpSpawnChance && powerUpPrefab != null)
        {
            int powerUpSpawnIndex = Random.Range(2, 5);
            Transform powerUpSpawnPoint = transform.GetChild(powerUpSpawnIndex).transform;

           
            Vector3 spawnPosition = powerUpSpawnPoint.position + Vector3.up * 1f;

            GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity, transform);
            powerUp.tag = "PowerUp"; 
        }
    }
}
