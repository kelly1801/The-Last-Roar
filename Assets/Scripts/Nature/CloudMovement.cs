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
        if (HasReachedPosition())
        {
            ReturnInitialPoint();
        }
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
        _transform.position = new Vector3(firstX, firstY, firstZ);
    }

    private bool HasReachedPosition()
    {
        return _transform.position.x < lastX;
    }

}
