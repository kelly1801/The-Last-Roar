using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pauser : MonoBehaviour
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
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
        GameManager.Pause = false;
        pausePanel.gameObject.SetActive(false);
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
