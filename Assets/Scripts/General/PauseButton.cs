using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour
{
    [SerializeField] private Image pausePanel;

    private PlayerController playerController;

    private void Start()
    {
        pausePanel.gameObject.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        if (GameManager.Pause)
        {
            Continue();
        }
        else
        {
            Stop();
        }
    }

    private void Continue()
    {
        if (playerController != null)
        {
            playerController.enabled = true;
        }
        pausePanel.gameObject.SetActive(false);
        GameManager.Pause = false;
    }

    private void Stop()
    {
        if (playerController != null)
        {
            playerController.enabled = false;
        }
        GameManager.Pause = true;
        pausePanel.gameObject.SetActive(true);
    }

}
