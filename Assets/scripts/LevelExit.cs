
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() == null)
            return;

        string levelName = SceneManager.GetActiveScene().name;

        Debug.Log(levelName + " COMPLETED!");
    }
}
