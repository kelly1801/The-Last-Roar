using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIObserver : MonoBehaviour
{
    [SerializeField] Crossfade crossfade;
    [SerializeField] ScenesManager scenesManager;

    private void Start()
    {
        scenesManager.openCrossfadeEvent += PlayOpenCrossfade;
        scenesManager.exitCrossfadeEvent += PlayExitCrossfade;
    }

    private void PlayOpenCrossfade()
    {
        crossfade.DisappearCrossfade();
    }

    private void PlayExitCrossfade()
    {
        StartCoroutine(PlayExitCrossfadeCoroutine());
    }

    private IEnumerator PlayExitCrossfadeCoroutine()
    {
        crossfade.AppearCrossfade();
        yield return new WaitForSeconds(crossfade.ExitClipLength);
        SceneManager.LoadScene(ScenesManager.Scene);
    }
}
