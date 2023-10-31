using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIKey
{
    #region serializedfield
    [SerializeField] Image image;
    [SerializeField] KeyCode keyCode;
    #endregion

    #region publicproperties
    public Image Image { get => image; set => image = value; }
    public KeyCode KeyCode { get => keyCode; set => keyCode = value; }
    #endregion
}