using UnityEngine;

public class CharSelectedManager : MonoBehaviour
{
    [SerializeField] GameObject dinoChar;
    [SerializeField] GameObject frogChar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0; // timeScale manage how fast the game runs, 1.5 the game runs faster 1.5x, 0 is no run(pause)
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void ChooseCharacter(int index)
    {
        // index = 1 -> Dino; index = 2 -> Frog
        if (index == 1)
        {
            dinoChar.SetActive(true);
            frogChar.SetActive(false);
        }
        else
        {
            frogChar.SetActive(true);
            dinoChar.SetActive(false);
        }
        BeginGame();
    }
}
