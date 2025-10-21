using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Torque Amount")]
    [SerializeField] float baseTorqueAmount = 20f;
    [SerializeField] float torqueAmountOnAir = 35f;
    float torqueAmount = 20f;

    [Header("Speed")]
    [SerializeField] float baseSpeed = 30f;
    [SerializeField] float boostSpeed = 50f;

    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    CapsuleCollider2D capsuleCollider2D;

    public bool isFinish = false;
    public bool isDead = false;
    float previousRotation;
    float totalRotation;
    int flipCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinish || isDead)
        {
            StartCoroutine(ReloadScene());
            return;
        }
        
        UpdateTorqueAMount();
        RotatePlayer();
        BoostPlayer();
        CalculateFlips();
    }

    void UpdateTorqueAMount()
    {
        if (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Floor")))
        {
            torqueAmount = baseTorqueAmount;
        }
        else
        {
            torqueAmount = torqueAmountOnAir;
        }
    }

    void BoostPlayer()
    {
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        myRigidbody2D.AddTorque(-moveVector.x * torqueAmount);
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.Abs(Mathf.DeltaAngle(previousRotation, currentRotation));
        previousRotation = currentRotation;

        flipCount = (int)(totalRotation / 360);
    }

    public int GetFlipCount()
    {
        return flipCount;
    }
}
