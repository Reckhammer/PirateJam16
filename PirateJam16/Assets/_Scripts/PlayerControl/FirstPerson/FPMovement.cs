using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    public float walkingSpeed  = 20f;
    private float currentSpeed;
    [Tooltip("The lower the value, the longer it takes for the momentum to lower")]
    public float momentumDamping = 5f;
    public float playerGravity = -10f;
    public bool canMove = true;
    private bool isWalking = false;

    [Header("Sprinting")]
    public bool canSprint = true;
    public float sprintSpeed  = 30f;
    private bool isSprinting = false;

    private CharacterController myController;
    private Vector3 inputVector;
    private Vector3 movementVector;

    // Move this out to it's own script
    public bool headBobEnabled = false;
    public Animator camAnimator;

    private void Awake()
    {
        myController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        // Put this in some sort of player manager?
        GetComponent<Health>().Death += DisableMovement;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();

        SetAnimations();
    }

    private void GetInput()
    {
        // Todo: use actual input system
        if (IsMovementInputDown())
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // Get player inputs
            inputVector.Normalize(); // Normalize the vector to prevent vectors being added during diagonal
            inputVector = transform.TransformDirection(inputVector); // Make the movement relative to the player

            isWalking = true;
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);

            isWalking = false;
        }

        if (canSprint && Input.GetKey(KeyCode.LeftShift))
            isSprinting = true;
        else
            isSprinting = false;

        currentSpeed = isSprinting ? sprintSpeed : walkingSpeed;

        movementVector = (inputVector * currentSpeed) + (Vector3.up * playerGravity);
    }

    private bool IsMovementInputDown()
    {
        // Todo use input action system
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
            return true;
        else
            return false;
    }

    private void MovePlayer()
    {
        if (canMove)
            myController.Move(movementVector * Time.deltaTime);
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    private void SetAnimations()
    {
        if (!headBobEnabled) return;

        camAnimator.SetBool("IsWalking", isWalking);
    }
}
