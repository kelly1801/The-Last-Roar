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

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
        characterController = GetComponent<CharacterController>();
      
    }
    private void Start()
    {
        gameInput.OnInteractAction += OnInteractAction;
        gameInput.OnRunAction += OnRunAction;
        gameInput.OnRunCanceled += OnRunCanceled;
        GameManager.Instance.GameOver += OnGameOver;
        GameManager.Instance.Victory += OnVictory;
        GameManager.Instance.EggPicked += OnEggPicked;



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
        GameManager.Instance.eggsPicked++;
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
        // activate running animation
        // works with R y SHIFT
    }

    private void OnRunCanceled(object sender, EventArgs e)
   {
    Debug.Log("STOPPED RUNNING");
    // Your code to handle the Run key being released
   }

   private void OnGameOver(object sender, EventArgs e)
    {
        Debug.Log("GAME OVEEEEEEEEEEEEEEEEEEEEEEEEEEEER");
        // Your code to handle the Game Over event
    }

     private void OnVictory(object sender, EventArgs e)
    {
        Debug.Log("WOOOOOOOOOOOOOOOOOOOOOOOOOOOON");
    }

  private void OnEggPicked(object sender, EventArgs e)
   {
    Debug.Log("picked from the PLAYEEEEEEEEEEEEEEEER");
    bool hasEgg = HasEgg();
    Debug.Log(sender);
    }

    public Transform GetEggNewTransform() {
      return playerPickPoint;
    }

 public bool HasEgg()
{
  return pickedEgg != null;
}

}
