using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private GameObject objectToActivate;
    #endregion

    #region publicmethods
    public void Activate()
    {
        objectToActivate.SetActive(true);
    }
    #endregion
}