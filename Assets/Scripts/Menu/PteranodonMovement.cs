using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Pteranodon : MonoBehaviour
{
    [Header("MOVEMENT")]
    [SerializeField][Min(0)] private float positionSpeed = 5f;
    [SerializeField][Min(0)] private float rotationSpeed = 5f;

    [Header("TARGET POSITIONS")]
    [SerializeField] private Transform[] positions;

    private Transform _transform;
    private Animator _animator;

    private Transform targetTransform;

    private void Start()
    {
        _transform = transform;
        _animator = gameObject.GetComponent<Animator>();

        _animator.SetBool("isFlying", true);

        targetTransform = GetTargetTransform();
    }

    private void Update()
    {
        Move();

        if (HasReachedPosition())
        {
            targetTransform = GetTargetTransform(); // get new target position
        }
    }

    private void Move()
    {
        Fly();
        Rotate();
    }

    private void Fly()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, targetTransform.position, positionSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector3 direction = targetTransform.position - _transform.position;

        if (direction.normalized != Vector3.zero)
        {
            Quaternion nextDirection = Quaternion.LookRotation(direction.normalized);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, nextDirection, rotationSpeed * Time.deltaTime);
        }
    }

    private Transform GetTargetTransform()
    {
        return positions[Random.Range(0, positions.Length)];
    }

    private bool HasReachedPosition()
    {
        return Vector3.Distance(_transform.position, targetTransform.position) < 0.1f;
    }
}