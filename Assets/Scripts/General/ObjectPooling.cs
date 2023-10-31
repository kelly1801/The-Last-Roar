using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private GameObject swimmerModel;
    [SerializeField] private Transform pool;
    [SerializeField] private int quantity;
    [SerializeField] private float seconds;
    #endregion

    #region publicproperties
    public float Seconds { get => seconds; }
    #endregion

    #region publicmethods
    public GameObject PullOne()
    {
        foreach (Transform swimmerTransform in pool)
        {
            if (!swimmerTransform.gameObject.activeSelf)
            {
                return swimmerTransform.gameObject;
            }
        }
        return null;
    }

    public void FillPool()
    {
        for (int i = 0; i < quantity; i++)
        {
            PushOne();
        }
    }
    #endregion

    #region privatemethods
    private void PushOne()
    {
        GameObject swimmer = Instantiate(swimmerModel, pool.position, Quaternion.identity, pool);
        swimmer.SetActive(false);
    }
    #endregion
}
