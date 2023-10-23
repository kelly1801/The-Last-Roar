using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CameraActivator : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera currentCamera;
    [SerializeField] private CinemachineVirtualCamera nextCamera;

    private Button _button;

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(Activate);
    }

    private void Activate()
    {
        nextCamera.gameObject.SetActive(true);
        currentCamera.gameObject.SetActive(false);
    }
}
