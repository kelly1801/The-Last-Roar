using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    #region privatemethods
    private void FixedUpdate()
    {
        Check();
    }

    private void Check()
    {
        if (GameManager.GameOver)
        {
            SceneLoader.LoadLastScene();
            Destroy(GameManager.Instance);
            enabled = false;
        }
    }
    #endregion
}