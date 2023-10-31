using UnityEngine;
using UnityEngine.UI;

public class KeyRenderer : MonoBehaviour
{
    #region serializedfields
    [Header("IMAGES OF KEYS")]
    [SerializeField] UIKey[] keys;

    [Header("COLORS")]
    [SerializeField] private Color usualColor;
    [SerializeField] private Color pressColor;

    [Header("SECONDS")]
    [SerializeField] private float secondsToRender;
    #endregion

    #region privatefields
    private float secondsElapsed = 0;
    #endregion

    #region privatemethods
    private void Start()
    {
        secondsElapsed = 0;
    }

    private void FixedUpdate()
    {
        secondsElapsed += Time.deltaTime;

        if (secondsElapsed < secondsToRender)
        {
            ColorizeAllKeys();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void ColorizeAllKeys()
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
    #endregion
}
