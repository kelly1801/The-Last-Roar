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

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
        characterController = GetComponent<CharacterController>();
        playerHeight = characterController.height;
        playerRadius = characterController.radius;
    
    }
    private void Start()
    {
        gameInput.OnInteractAction += OnInteractAction;
        gameInput.OnRunAction += OnRunAction;
        gameInput.OnRunCanceled += OnRunCanceled;

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

        

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

    }

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
        // activate running animation
        // works with R y SHIFT
    }

    private void OnRunCanceled(object sender, EventArgs e)
   {
    Debug.Log("STOPPED RUNNING");
    // Your code to handle the Run key being released
   }
}
