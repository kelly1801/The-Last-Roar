using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayGame : MonoBehaviour
{
    #region serializedfields
    [SerializeField] MeteoriteRain meteoriteRain;
    [SerializeField] float delay;
    #endregion

    #region privatefields
    private Button _button;
    #endregion

    #region privatemethods
    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(() => StartCoroutine(Play()));
    }
    #endregion

    #region coroutines
    private IEnumerator Play()
    {
        meteoriteRain.Run();
        yield return new WaitForSeconds(delay);
        SceneLoader.LoadNextScene();
    }
    #endregion
}
