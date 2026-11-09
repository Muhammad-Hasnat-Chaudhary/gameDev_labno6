
using UnityEngine;

public class AccessCardPickup : MonoBehaviour
{
    [Header("Door to Unlock")]
    public SecurityDoor securityDoor;

    [Header("Exit Zone")]
    public LevelExit levelExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() == null)
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

        if (levelExit != null)
        {
            levelExit.SetAccessCardCollected();
        }
        else
        {
            Debug.LogWarning("Level Exit not assigned!");
        }

        gameObject.SetActive(false);
    }
}
