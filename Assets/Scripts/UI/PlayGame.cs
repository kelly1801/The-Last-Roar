using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayGame : MonoBehaviour
{
    [SerializeField] MeteoriteRain meteoriteRain;
    [SerializeField] float delay;

    private Button _button;

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(Play);
    }

    private void Play()
    {
        StartCoroutine(PlayCoroutine());
    }

    private IEnumerator PlayCoroutine()
    {
        meteoriteRain.Run();
        yield return new WaitForSeconds(delay);
        SceneLoader.LoadNextScene();
    }
}
