using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 5.0f;
    private float playerRadius;
    private float playerHeight;
    public bool nearNest = false;

    private static bool gameOver;
    private static bool victory;

    public static bool GameOver{get => gameOver;}
    public static bool Victory{get => victory;}

    [SerializeField] private Transform playerPickPoint;

    public Egg pickedEgg;
    private GameInput gameInput;
    private Animator dinoAnimator;

    private bool isRunning;

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
        dinoAnimator = GetComponent<Animator>();
        playerRadius = GetComponent<CharacterController>().radius;
        playerHeight = GetComponent<CharacterController>().height;

    }
    private void Start()
    {
        gameOver = false;
        victory = false;

        gameInput.OnInteractAction += OnInteractAction;
        gameInput.OnRunAction += OnRunAction;
        gameInput.OnRunCanceled += OnRunCanceled;
        gameInput.OnAttackAction += OnAttackAction;
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

        bool canMove = CollisionDetection(moveDirection, moveDistance);


        if (!dinoAnimator.GetBool("isRunning")) dinoAnimator.SetBool("isWalking", inputVector == new Vector2(0, 0) ? false : true);

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;

        }
        if (inputVector != Vector2.zero)
        {
            dinoAnimator.SetBool("isWalking", true);

        }
        else
        {
            dinoAnimator.SetBool("isWalking", false);


        }

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

    }

    private void OnInteractAction(object sender, EventArgs e)
    {
        // Check if the player is near a Nest object and has an egg
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.0f);


        if (nearNest && HasEgg())
        {
            DestroyEgg();
            GameManager.EggsDropped++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nest"))
        {
            nearNest = true;

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

    private bool CollisionDetection(Vector3 moveDirection, float moveDistance)
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
    private void OnRunAction(object sender, EventArgs e)
    {
        dinoAnimator.SetBool("isWalking", false);
        Vector2 inputVector = gameInput.GetMovementVector();
        bool ShouldRun = inputVector != Vector2.zero && moveSpeed > 0.0f;
        dinoAnimator.SetBool("isRunning", ShouldRun);
        if (ShouldRun)
        {
            moveSpeed *= 2.0f;
            isRunning = true;
        }
    }

    private void OnRunCanceled(object sender, EventArgs e)
    {
        Debug.Log("STOPPED RUNNING");
        dinoAnimator.SetBool("isRunning", false);
        moveSpeed = isRunning ? moveSpeed / 2.0f : moveSpeed;
        isRunning = false;
        // Your code to handle the Run key being released
    }

    private void OnGameOver(object sender, EventArgs e)
    {
        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        dinoAnimator.SetBool("isDead", true);
        yield return new WaitForSeconds(3);
        Debug.Log("GAME OVEEEEEEEEEEEEEEEEEEEEEEEEEEEER");
        gameOver = true;
        this.enabled = false;
    }

    private void OnVictory(object sender, EventArgs e)
    {
        Debug.Log("WOOOOOOOOOOOOOOOOOOOOOOOOOOOON");
        victory = true;
        this.enabled = false;
    }
    private void OnAttackAction(object sender, EventArgs e)
    {
        Debug.Log("ATACKKKKKKKKKKKKKKKKKKKKKKK");
        dinoAnimator.SetBool("isAttacking", true);
    }

    public Transform GetEggNewTransform()
    {
        return playerPickPoint;
    }



    public bool HasEgg()
    {
        return pickedEgg != null;
    }

}
