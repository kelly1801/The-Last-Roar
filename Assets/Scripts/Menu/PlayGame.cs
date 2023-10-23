using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayeGame : MonoBehaviour
{
    [SerializeField] private string gameScene;

    private Button _button;

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(Activate);
    }

    private void Activate()
    {
       
        

    }
}
