using System;
using UnityEngine;
using UnityEngine.UI;

public class KeyRenderer : MonoBehaviour
{

    [Header("IMAGES OF KEYS")]

    [SerializeField] UIKey[] keys;

    [Header("COLORS")]
    [SerializeField] private Color usualColor;
    [SerializeField] private Color pressColor;

    [Header("SECONDS")]
    [SerializeField] private float secondsToRender;

    private float secondsElapsed = 0;

    private void Start()
    {
        secondsElapsed = 0;
    }

    private void FixedUpdate()
    {
        secondsElapsed += Time.deltaTime;

        if (secondsElapsed < secondsToRender)
        {
            Colorize();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Colorize()
    {
        foreach (UIKey key in keys)
        {
            ColorizeKey(key.Image, key.KeyCode);
        }
    }

    private void ColorizeKey(Image image, KeyCode key)
    {
        if (Input.GetKey(key))
        {
            image.color = pressColor;
        }
        else
        {
            image.color = usualColor;
        }
    }
}
