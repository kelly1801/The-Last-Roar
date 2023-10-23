using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    [Header("SPEED")]
    [SerializeField] private float velocityX;
    [SerializeField] private float velocityY;
    [SerializeField] private float velocityZ;

    [Header("FIRST POSITION")]
    [SerializeField] private float firstX;
    [SerializeField] private float firstY;
    [SerializeField] private float firstZ;

    [Header("LAST POSITION")]
    [SerializeField] private float lastX;
    [SerializeField] private float lastY;
    [SerializeField] private float lastZ;

    private Transform _transform;


    private void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        Move();
        ReturnInitialPoint();
    }

    private void Move()
    {
        float x = velocityX * Time.deltaTime;
        float y = velocityY * Time.deltaTime;
        float z = velocityZ * Time.deltaTime;

        _transform.Translate(new Vector3(x, y, z));
    }

    private void ReturnInitialPoint()
    {
        if (_transform.position.x < lastX)
        {
            _transform.position = new Vector3(firstX, firstY, firstZ);
        }
    }

}
