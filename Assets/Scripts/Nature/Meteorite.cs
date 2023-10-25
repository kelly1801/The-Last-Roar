using System.Collections;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] private float deactivationSeconds;

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

    private IEnumerator Deactivate(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}