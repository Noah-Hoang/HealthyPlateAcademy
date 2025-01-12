using Fusion;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Keyboard;

public class IntroButtons : MonoBehaviour
{
    public TMP_InputField roomNameInputField;
    public TMP_InputField characterNameInputField;
    public static string characterName;
    public FusionBootstrap fusionBootstrap;
    public KeyChannel keyChannel;
    public KeyboardManager keyboardManager;

    public void OnEnable()
    {
        //FindObjectOfType searches through entire scene for something, in this case FusionBootstrap
        fusionBootstrap = FindObjectOfType<FusionBootstrap>();
        //Listens for when the text of the input field changes then calls the method
        roomNameInputField.onEndEdit.AddListener(UpdateRoomName);
        characterNameInputField.onEndEdit.AddListener(UpdateCharacterName);
        roomNameInputField.text = "Room:" + Random.Range(0000, 9999).ToString();
        keyChannel.OnKeyPressed += OnRoomKeyPressed;
        roomNameInputField.onSelect.AddListener(OnRoomInputFieldSelected);
        characterNameInputField.onSelect.AddListener(OnCharacterInputFieldSelected);
    }
    
    public void OnRoomInputFieldSelected(string str)
    {
        keyboardManager.outputField = roomNameInputField;
        keyChannel.OnKeyPressed -= OnCharacterKeyPressed;
        keyChannel.OnKeyPressed += OnRoomKeyPressed;
    }

    public void OnCharacterInputFieldSelected(string str)
    {
        keyboardManager.outputField = characterNameInputField;
        keyChannel.OnKeyPressed -= OnRoomKeyPressed;
        keyChannel.OnKeyPressed += OnCharacterKeyPressed;
    }

    public void OnRoomKeyPressed(string character)
    {
        roomNameInputField.text = character;
        keyChannel.OnKeyPressed -= OnRoomKeyPressed;
    }

    public void OnCharacterKeyPressed(string character)
    {
        characterNameInputField.text = character;
        keyChannel.OnKeyPressed -= OnCharacterKeyPressed;
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

        //Wait a frame so the asyncLoad variable is set up before we start to use it
        yield return null;
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

    public void UpdateCharacterName(string charName)
    {
        if (!string.IsNullOrEmpty(charName))
        {
            characterName = characterNameInputField.text;
        }
    }
}
