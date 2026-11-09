
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private bool accessCardCollected = false;

    public void SetAccessCardCollected()
    {
        accessCardCollected = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() == null)
            return;

        if (!accessCardCollected)
        {
            Debug.Log("ACCESS DENIED! Collect the access card first.");
            return;
        }

        string levelName = SceneManager.GetActiveScene().name;
        Debug.Log(levelName + " COMPLETED!");
    }
}
