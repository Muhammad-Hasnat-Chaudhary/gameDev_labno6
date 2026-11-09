
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private bool accessCardCollected = false;
    private bool levelCompleted = false;

    public void SetAccessCardCollected()
    {
        accessCardCollected = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() == null)
            return;

        if (levelCompleted)
            return;

        if (!accessCardCollected)
        {
            Debug.Log("ACCESS DENIED! Collect the access card first.");
            return;
        }

        levelCompleted = true;

        Scene currentScene = SceneManager.GetActiveScene();

        Debug.Log(currentScene.name + " COMPLETED!");

        int nextLevelIndex = currentScene.buildIndex + 1;

        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Loading next level...");
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("CONGRATULATIONS! ALL 5 LEVELS COMPLETED!");
        }
    }
}
