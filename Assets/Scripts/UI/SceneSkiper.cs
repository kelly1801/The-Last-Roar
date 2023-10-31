using UnityEngine;

public class SceneSkiper : MonoBehaviour
{
    #region privatemethods
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneLoader.LoadNextScene();
            gameObject.SetActive(false);
        }
    }
    #endregion
}