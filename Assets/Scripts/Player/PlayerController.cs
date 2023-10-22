using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 5.0f;

    [SerializeField] private Transform playerPickPoint;
    private CharacterController characterController;
    public Egg pickedEgg;
    private GameInput gameInput;
    private Animator dinoAnimator;

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
        characterController = GetComponent<CharacterController>();
        dinoAnimator = GetComponent<Animator>();    
      
    }
    private void Start()
    {
        gameInput.OnInteractAction += OnInteractAction;
        gameInput.OnRunAction += OnRunAction;
        gameInput.OnRunCanceled += OnRunCanceled;
        GameManager.Instance.GameOver += OnGameOver;
        GameManager.Instance.Victory += OnVictory;

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

 private void OnInteractAction(object sender, EventArgs e)
{
    // Check if the player is near a Nest object and has an egg
    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.0f);
    bool nearNest = false;
    foreach (Collider hitCollider in hitColliders)
    {
        if (hitCollider.CompareTag("Nest"))
        {
            nearNest = true;
            break;
        }
    }

    if (nearNest && HasEgg())
    {
        DestroyEgg();
        GameManager.Instance.eggsDropped++;
        }
}

private void DestroyEgg()
{
    foreach (Transform child in playerPickPoint)
    {
        Egg egg = child.GetComponent<Egg>();
        if (egg != null)
        {
            egg.RemoveEggParent();
            Destroy(egg.gameObject);
            break;
        }
    }
}


    private void OnRunAction(object sender, EventArgs e)
    {
      
      Debug.Log("RUNNINGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG");
        moveSpeed *= 2.0f;
        dinoAnimator.SetBool("isRunning", true);
    }

    private void OnRunCanceled(object sender, EventArgs e)
   {
    Debug.Log("STOPPED RUNNING");
        dinoAnimator.SetBool("isRunning", false);
        moveSpeed /= 2.0f;
    // Your code to handle the Run key being released
   }

   private void OnGameOver(object sender, EventArgs e)
    {
        Debug.Log("GAME OVEEEEEEEEEEEEEEEEEEEEEEEEEEEER");
        dinoAnimator.SetBool("isDead", true);
    }

     private void OnVictory(object sender, EventArgs e)
    {
        Debug.Log("WOOOOOOOOOOOOOOOOOOOOOOOOOOOON");
        dinoAnimator.SetBool("isAttacking", true);
    }

    public Transform GetEggNewTransform() {
      return playerPickPoint;
    }

 public bool HasEgg()
{
  return pickedEgg != null;
}

}
