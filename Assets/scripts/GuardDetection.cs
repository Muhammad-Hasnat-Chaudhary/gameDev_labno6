
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardDetection : MonoBehaviour
{
    public float detectionDelay = 0.5f;

    private float detectionTimer;
    private bool playerDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
            detectionTimer = 0f;
            Debug.Log("Guard detected Remy!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player") || !playerDetected)
            return;

        detectionTimer += Time.deltaTime;

        if (detectionTimer >= detectionDelay)
        {
            playerDetected = false;
            Debug.Log("Remy caught! Restarting level.");
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            detectionTimer = 0f;
        }
    }
}
