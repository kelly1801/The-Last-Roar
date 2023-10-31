using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIKey
{
    [SerializeField] Image image;
    [SerializeField] KeyCode keyCode;

    public Image Image { get => image; set => image = value; }
    public KeyCode KeyCode { get => keyCode; set => keyCode = value; }
}