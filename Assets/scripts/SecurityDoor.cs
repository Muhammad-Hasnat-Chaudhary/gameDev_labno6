
using UnityEngine;

public class SecurityDoor : MonoBehaviour
{
    private bool isUnlocked = false;

    public void UnlockDoor()
    {
        if (isUnlocked)
            return;

        isUnlocked = true;

        Debug.Log("Security Door Unlocked!");

        gameObject.SetActive(false);
    }
}
