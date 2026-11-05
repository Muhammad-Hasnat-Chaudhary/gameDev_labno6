
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [Header("Spawn Settings")]
    public Transform spawnPoint;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (spawnPoint == null)
        {
            Debug.LogWarning("Player Spawn Point is not assigned!");
            return;
        }

        // Temporarily disable collision during teleportation.
        if (controller != null)
            controller.enabled = false;

        transform.SetPositionAndRotation(
            spawnPoint.position,
            spawnPoint.rotation
        );

        if (controller != null)
            controller.enabled = true;
    }
}
