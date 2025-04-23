using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab; // Asigna el prefab del power-up en el Inspector
    public Transform playerTransform; // Asigna el transform del jugador en el Inspector

    public float spawnInterval = 10f; // Tiempo entre spawns
    public float spawnDistance = 30f; // Distancia delante del jugador donde aparecerá el power-up
    public float laneWidth = 2f; // Ancho entre carriles
    public int numberOfLanes = 3; // Número de carriles

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPowerUp();
            timer = 0f;
        }
    }

    void SpawnPowerUp()
    {
        // Determinar carril aleatorio
        int lane = Random.Range(0, numberOfLanes);
        float xOffset = (lane - (numberOfLanes / 2)) * laneWidth;

        // Posición de spawn delante del jugador
        Vector3 spawnPosition = new Vector3(
            playerTransform.position.x + xOffset,
            playerTransform.position.y,
            playerTransform.position.z + spawnDistance
        );

        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
    }
}
