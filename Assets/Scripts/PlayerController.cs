using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] private float playerHeight, playerRadius;
    private CharacterController characterController;
    private GameInput gameInput;
    private Animator dinoAnimator;

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
        characterController = GetComponent<CharacterController>();
        dinoAnimator = GetComponent<Animator>();
        playerHeight = characterController.height;
        playerRadius = characterController.radius;
    
    }
    private void Start()
    {
        gameInput.OnInteractAction += OnInteractAction;
        gameInput.OnRunAction += OnRunAction;
    }
    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        Vector3 moveDirection = new(inputVector.x, 0.0f, inputVector.y);
        float moveDistance = moveSpeed * Time.deltaTime;

        characterController.Move(moveDirection * moveDistance);

        dinoAnimator.SetBool("isWalking", inputVector == new Vector2(0, 0) ? false : true);

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

    }

 /*   private bool CollisionDetection(Vector3 moveDirection, float moveDistance)
    {
        // checks if the object is colliding, if false is not colliding so we get the opposite
        bool canMove = !Physics.CapsuleCast(
            transform.position,
            transform.position + Vector3.up * playerHeight,
            playerRadius,
            moveDirection,
            moveDistance
            );
        return canMove;
    }
 */
    private void OnInteractAction(object sender, EventArgs e)
    {
        Debug.Log("INTERACTIIIIIIIIIIIIIIIIIIIIIIIIIIIIING");
    // do eggs interaction
    // works with e or space
    // add buttons for joystick and gamepad

    }

    private void OnRunAction(object sender, EventArgs e)
    {
      
      Debug.Log("RUNNINGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG");
        dinoAnimator.SetBool("isWalking", true);
        // works with R y SHIFT
    }

}
