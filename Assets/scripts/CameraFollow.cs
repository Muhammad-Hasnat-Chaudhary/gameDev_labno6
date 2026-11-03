
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Target")]
    public Transform target;

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0f, 3.5f, -5f);
    public float smoothSpeed = 10f;
    public float lookHeight = 1.5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Follow behind the player's facing direction.
        Vector3 desiredPosition =
            target.position + target.rotation * offset;

        // Smooth camera movement.
        float smoothing =
            1f - Mathf.Exp(-smoothSpeed * Time.deltaTime);

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothing
        );

        // Look at the player's upper body.
        Vector3 lookTarget =
            target.position + Vector3.up * lookHeight;

        transform.rotation = Quaternion.LookRotation(
            lookTarget - transform.position,
            Vector3.up
        );
    }
}
