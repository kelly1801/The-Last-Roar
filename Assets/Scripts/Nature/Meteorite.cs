using System.Collections;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private float deactivationSeconds;
    #endregion

    #region privatemethods
    private void OnEnable()
    {
        StartCoroutine(Deactivate(deactivationSeconds * 2));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(Deactivate(deactivationSeconds));
        }
    }
    #endregion

    #region coroutines
    private IEnumerator Deactivate(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
    #endregion
}