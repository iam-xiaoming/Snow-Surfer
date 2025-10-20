using UnityEngine;

public class CrashDetection : MonoBehaviour
{
    PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void OnCollisionEnter2D(Collision2D other)
    { 
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerIndex)
        {
            playerController.isDead = true;
        }
    }
}
