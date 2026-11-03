
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 4f;
    public float rotationSpeed = 12f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Transform cameraTransform;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (cameraTransform == null)
            return;

        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W))
            vertical += 1f;

        if (Input.GetKey(KeyCode.S))
            vertical -= 1f;

        if (Input.GetKey(KeyCode.A))
            horizontal -= 1f;

        if (Input.GetKey(KeyCode.D))
            horizontal += 1f;

        // Get camera-relative directions.
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection =
            forward * vertical +
            right * horizontal;

        moveDirection = Vector3.ClampMagnitude(
            moveDirection, 1f
        );

        // Move and rotate the player.
        if (moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // Gravity.
        if (controller.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 movement =
            moveDirection * moveSpeed +
            Vector3.up * verticalVelocity;

        controller.Move(movement * Time.deltaTime);
    }
}
