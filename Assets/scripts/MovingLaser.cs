
using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 1.5f;

    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float offset = Mathf.PingPong(
            Time.fixedTime * moveSpeed,
            moveDistance * 2f
        ) - moveDistance;

        Vector3 targetPosition =
            startPosition + Vector3.forward * offset;

        if (rb != null)
            rb.MovePosition(targetPosition);
        else
            transform.position = targetPosition;
    }
}
