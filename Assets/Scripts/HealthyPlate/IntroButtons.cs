using Fusion;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class IntroButtons : MonoBehaviour
{
    public GameObject networkHandler; // Assign this in the Inspector   

    public void StandardMode()
    {
        Debug.Log("Play Standard Mode");

        // Load the target scene
        StartCoroutine(LoadSceneAndStartNetwork("StandardModeScene"));
    }

    public void InstructorMode()
    {
        Debug.Log("Play Instructor Mode");

        // Load another target scene or handle logic here
        StartCoroutine(LoadSceneAndStartNetwork("InstructorModeScene"));
    }

    private IEnumerator LoadSceneAndStartNetwork(string sceneName)
    {
        // Load the target scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait for the scene to finish loading
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Debug.Log($"Scene {sceneName} loaded successfully!");

        // Start the network connection
        if (networkHandler != null)
        {
            networkHandler.GetComponent<FusionBootstrap>().StartSharedClient();
            Debug.Log("Network connection started!");
        }
        else
        {
            Debug.LogError("Network handler is not assigned!");
        }
    }
}
