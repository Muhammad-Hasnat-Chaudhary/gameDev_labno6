
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() == null)
            return;

        Debug.Log("LEVEL 1 COMPLETED!");
    }
}
