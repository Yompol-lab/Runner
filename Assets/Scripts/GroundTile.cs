using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    [System.Obsolete]
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }



    private void Update()
    {
        
    }
}
