using UnityEngine;

public class MeteoriteRain : MonoBehaviour
{
    #region serializedfields
    [Header("Parameters")]
    [SerializeField] private ObjectPooling meteoritePool;
    [SerializeField] private float velY = 5f;
    [SerializeField] private float velX = 5f;
    [SerializeField] private float velZ = 5f;

    [Header("Origin")]
    [SerializeField] private Transform rainOrigin;

    [Header("Spawn Origin")]
    [SerializeField] private BoxCollider spawnArea; // spawn area
    #endregion

    #region privatefields
    private Vector3 min;
    private Vector3 max;
    #endregion

    #region publicmethods
    public void Run()
    {
        InvokeRepeating(nameof(PoolingCycle), 0, meteoritePool.Seconds);
    }
    #endregion

    #region privatemethods
    private void Start()
    {
        Bounds bounds = spawnArea.bounds;

        min = bounds.min; // left-down corner
        max = bounds.max; // right-up corner

        meteoritePool.FillPool();
    }

    private void PoolingCycle()
    {
        GameObject meteorite = meteoritePool.PullOne();

        if (meteorite != null)
        {
            meteorite.transform.position = new(Random.Range(min.x, max.x), rainOrigin.position.y, Random.Range(min.z, max.z));
            Rigidbody rigidBody = meteorite.GetComponent<Rigidbody>();
            rigidBody.velocity = new Vector3(velX, velY, velZ);
            meteorite.SetActive(true);
        }
    }
    #endregion
}