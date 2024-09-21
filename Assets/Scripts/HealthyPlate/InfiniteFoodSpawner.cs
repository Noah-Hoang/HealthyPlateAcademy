using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Fusion;
using Unity.VisualScripting;
using Fusion.Sockets;
using System;

public class InfiniteFoodSpawner : NetworkBehaviour, ISceneLoadDone
{
    public GameObject food;
    public GameObject currentSpawnedFood;

    public void SceneLoadDone(in SceneLoadDoneArgs sceneInfo)
    {
        Debug.Log("HELLO");
        //Spawns in a food at start and sets that food to currentSpawnedFood
        //Adds a listener onto that food for when it is grabbed
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        NetworkObject networkObject = Runner.Spawn(food, pos, rot);
        currentSpawnedFood = networkObject.gameObject;
        currentSpawnedFood.GetComponent<XRGrabInteractable>().firstSelectEntered.AddListener(SpawnFood);
    }

    public void SpawnFood(SelectEnterEventArgs selectFood)
    {
        //When food is grabbed, unsubscribe to the one that was grabbed
        //Spawns in new food and sets it to currentSpawnedFood
        //Adds listener to the newly spawned food
        currentSpawnedFood.GetComponent<XRGrabInteractable>().firstSelectEntered.RemoveListener(SpawnFood);
        currentSpawnedFood = Runner.Spawn(food, transform.position, transform.rotation).gameObject;
        currentSpawnedFood.GetComponent<XRGrabInteractable>().firstSelectEntered.AddListener(SpawnFood);
    } 
}
