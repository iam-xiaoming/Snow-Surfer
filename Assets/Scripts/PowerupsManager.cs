using UnityEngine;

public class PowerupsManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;
    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.ActivatePowerup(powerup);
            Destroy(gameObject);
        }
    }
}
