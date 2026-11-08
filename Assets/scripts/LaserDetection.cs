
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() == null)
            return;

        Debug.Log("LASER DETECTED REMY! Restarting level.");

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
