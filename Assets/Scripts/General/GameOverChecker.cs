using UnityEngine;

public class GameOverChecker : MonoBehaviour
{

    private void FixedUpdate()
    {
        Check();
    }

    private void Check()
    {
        if (PlayerController.GameOver)
        {
            SceneLoader.LoadLastScene();
            gameObject.SetActive(false);
        }
        else if (PlayerController.Victory)
        {
            SceneLoader.LoadNextScene();
            gameObject.SetActive(false);
        }
    }
}