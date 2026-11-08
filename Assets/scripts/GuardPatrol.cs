
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float rotationSpeed = 5f;
    public float stoppingDistance = 0.2f;

    private Transform currentTarget;

    void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Guard patrol points are missing!");
            enabled = false;
            return;
        }

        currentTarget = pointA;
    }

    void Update()
    {
        Vector3 targetPosition = currentTarget.position;
        targetPosition.y = transform.position.y;

        Vector3 direction = targetPosition - transform.position;

        if (direction.magnitude <= stoppingDistance)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
            return;
        }

        // Rotate smoothly toward the patrol destination.
        Quaternion targetRotation =
            Quaternion.LookRotation(direction.normalized);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        // Move toward the destination.
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }
}
