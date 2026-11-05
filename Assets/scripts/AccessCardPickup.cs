
using UnityEngine;

public class AccessCardPickup : MonoBehaviour
{
    [Header("Door to Unlock")]
    public SecurityDoor securityDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<CharacterController>())
            return;

        Debug.Log("Access Card Collected!");

        if (securityDoor != null)
        {
            securityDoor.UnlockDoor();
        }
        else
        {
            Debug.LogWarning("Security Door not assigned!");
        }

        gameObject.SetActive(false);
    }
}
