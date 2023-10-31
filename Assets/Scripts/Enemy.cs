using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float dangerDistance = 10f; // Set the danger distance here
    [SerializeField] private Image panelImage; // Reference to the UI panel's Image component
    private NavMeshAgent agent;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        agent.destination = player.transform.position;
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < dangerDistance)
        {

            // Set the alpha value of the panel to 50% visibility
            Color panelColor = panelImage.color;
            panelColor.a = 0.5f;
            panelImage.color = panelColor;

            if (distanceToPlayer < 5)
            {
                gameManager.OnGameOver();

            }

        }
        else
        {
            // If the distance is not too close, set the alpha value to 0 (0% visibility)
            Color panelColor = panelImage.color;
            panelColor.a = 0f;
            panelImage.color = panelColor;
        }


    }

}
