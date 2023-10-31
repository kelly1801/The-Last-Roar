using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    public void Start()
    {
        objectToActivate.SetActive(true);
    }
}