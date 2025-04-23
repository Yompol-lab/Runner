using UnityEngine;

public class PowerUpInvincibility : MonoBehaviour
{
    public float duration = 5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInvincibility playerInvincibility = other.GetComponent<PlayerInvincibility>();
            if (playerInvincibility != null)
            {
                playerInvincibility.ActivateInvincibility(duration);
            }

            Destroy(gameObject); 
        }
    }
}
