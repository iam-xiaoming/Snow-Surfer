using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 5f;
    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    public bool isFinish = false;
    public bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        // print(moveVector);
        myRigidbody2D.AddTorque(-moveVector.x * torqueAmount);

        if (isFinish || isDead)
        {
            StartCoroutine(ReloadScene());
        }

    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
