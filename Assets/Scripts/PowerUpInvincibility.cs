using UnityEngine;

public class PowerUpInvincibility : MonoBehaviour
{
    public float duration = 5f;          // Duración del power-up
    private PowerUpCounter counter;      // Referencia al contador

    [System.Obsolete]
    private void Start()
    {
        // Buscamos el contador en la escena
        counter = FindObjectOfType<PowerUpCounter>();
        if (counter == null)
        {
            Debug.LogWarning("PowerUpCounter no encontrado en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activamos la invencibilidad
            PlayerInvincibility inv = other.GetComponent<PlayerInvincibility>();
            if (inv != null)
            {
                inv.ActivateInvincibility(duration);
            }

            // Incrementamos el contador
            if (counter != null)
            {
                counter.Increment();
            }

            // Destruimos el power-up
            Destroy(gameObject);
        }
    }
}
