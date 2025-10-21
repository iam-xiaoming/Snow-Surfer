using UnityEngine;
using TMPro;

public class ScoresManager : MonoBehaviour
{
    [SerializeField] TMP_Text scores;
    PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        scores.text = $"Score: {playerController.GetFlipCount()}";
    }
}
