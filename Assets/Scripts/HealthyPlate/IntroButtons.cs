using Fusion;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UI;
using TMPro;

public class IntroButtons : MonoBehaviour
{
    public TMP_InputField roomNameInputField;
    public FusionBootstrap fusionBootstrap;

    public void OnEnable()
    {
        //FindObjectOfType searches through entire scene for something, in this case FusionBootstrap
        fusionBootstrap = FindObjectOfType<FusionBootstrap>();
        //Listens for when the text of the input field changes then calls the method
        roomNameInputField.onEndEdit.AddListener(UpdateRoomName);   
        fusionBootstrap.DefaultRoomName = "Room:" + Random.Range(0000, 9999).ToString();
        roomNameInputField.text = fusionBootstrap.DefaultRoomName;
    }
    public void StandardMode()
    {
        Debug.Log("Play Standard Mode");
        HealthyPlateManager.isInstructorMode = false;
        // Load the target scene
        StartCoroutine(LoadSceneAndStartNetwork("HealthyPlateAcademy_New"));
    }

    public void InstructorMode()
    {
        Debug.Log("Play Instructor Mode");
        HealthyPlateManager.isInstructorMode = true;
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

        
        // Start the network connection
        if (fusionBootstrap != null)
        {
            //checks whole scene for FusionBootstrap
            fusionBootstrap.StartSharedClient();           
            Debug.Log("Network connection started!");

            NetworkRunner networkRunner = FindObjectOfType<NetworkRunner>();
            //Makes sure that the server is connected to the network before destroying game object
            while (!networkRunner.IsConnectedToServer)
            {
                yield return null;
            }
            Destroy(gameObject);

            //fusionBootstrap.DefaultRoomName;
        }
        else
        {
            Debug.LogError("Network handler is not assigned!");
        }
    }

    private void UpdateRoomName(string newRoomName)
    {
        // Checks to see if the room name is empty or not
        if (!string.IsNullOrEmpty(newRoomName))
        {
            fusionBootstrap.DefaultRoomName = newRoomName;
            Debug.Log($"Room name set to: {newRoomName}");
        }
        else
        {
            Debug.LogWarning("Room name is empty!");
        }
    }
}
