using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CameraActivator : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private CinemachineVirtualCamera currentCamera;
    [SerializeField] private CinemachineVirtualCamera nextCamera;
    #endregion

    #region privatefields
    private Button _button;
    #endregion

    #region privatemethods
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
    #endregion
}
