using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;

    [System.Obsolete]
    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") 
        {
            playerMovement.Die();
        }
    }

    void Update()
    {
        
    }
}
