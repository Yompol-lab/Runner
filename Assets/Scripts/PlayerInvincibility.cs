using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    public string obstacleLayerName = "Obstaculo";
    private int obstacleLayer;
    private bool isInvincible = false;
    private float timer = 0f;

    void Start()
    {

        Debug.Log($"[Player] Layer actual del jugador: {gameObject.layer} ({LayerMask.LayerToName(gameObject.layer)})");

        obstacleLayer = LayerMask.NameToLayer(obstacleLayerName);

        if (obstacleLayer == -1)
        {
            Debug.LogError($"[Invincibility]  La capa '{obstacleLayerName}' no existe. Creala en Tags and Layers.");
        }
        else
        {
            Debug.Log($"[Invincibility]  Capa '{obstacleLayerName}' encontrada como Layer {obstacleLayer}.");
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
            Debug.LogWarning(" No se puede cambiar colisión porque la capa es inválida.");
            return;
        }

        isInvincible = value;
        Physics2D.IgnoreLayerCollision(gameObject.layer, obstacleLayer, value);
    }
}
