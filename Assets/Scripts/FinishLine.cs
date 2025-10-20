using System.Collections;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // using tag
        // if (other.CompareTag("Player"))
        // {
        //     playerController.isFinish = true;
        // }

        // using Layer
        int layerIndex = LayerMask.NameToLayer("Player");
        if (other.gameObject.layer == layerIndex)
        {
            playerController.isFinish = true;
        }
    }
}
