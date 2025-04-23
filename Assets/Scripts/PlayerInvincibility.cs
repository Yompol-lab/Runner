using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    public string obstacleLayerName = "Obstaculo";
    private int obstacleLayer;
    private bool isInvincible = false;
    private float timer = 0f;

    void Start()
    {
        obstacleLayer = LayerMask.NameToLayer(obstacleLayerName);
        Debug.Log($"[DEBUG] Player está en capa {gameObject.layer} ({LayerMask.LayerToName(gameObject.layer)})");
        Debug.Log($"[DEBUG] Capa obstáculo '{obstacleLayerName}' es {obstacleLayer}");

        if (obstacleLayer == -1)
        {
            Debug.LogError("La capa de obstáculo no existe.");
        }
    }

    void Update()
    {
        if (isInvincible)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                SetInvincibility(false);
            }
        }
    }

    public void ActivateInvincibility(float duration)
    {
        timer = duration;
        SetInvincibility(true);
    }

    private void SetInvincibility(bool value)
    {
        if (obstacleLayer == -1)
        {
            Debug.LogWarning("No se puede cambiar colisión porque la capa es inválida.");
            return;
        }

        isInvincible = value;
        Physics.IgnoreLayerCollision(gameObject.layer, obstacleLayer, value);
        Debug.Log($"[Invincibility] IGNORAR colisión Player({gameObject.layer}) ↔ Obstaculo({obstacleLayer}) = {value}");
    }
}
