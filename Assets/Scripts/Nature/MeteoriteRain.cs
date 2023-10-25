using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MeteoriteRain : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private ObjectPooling meteoritePool;
    [SerializeField] private float velY = 5f;
    [SerializeField] private float velX = 5f;
    [SerializeField] private float velZ = 5f;

    [Header("Origin")]
    [SerializeField] private Transform rainOrigin;

    [Header("Spawn Origin")]
    [SerializeField] private BoxCollider spawnArea;

    private Vector3 min;
    private Vector3 max;

    private void Start()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        Bounds bounds = boxCollider.bounds;

        min = bounds.min; // left-down corner
        max = bounds.max; // right-up corner

        meteoritePool.FillPool();
    }

    public void Run()
    {
        InvokeRepeating(nameof(PoolingCycle), 0, meteoritePool.Seconds);
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
}