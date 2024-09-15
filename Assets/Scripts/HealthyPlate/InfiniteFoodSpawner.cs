using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InfiniteFoodSpawner : MonoBehaviour
{
    public GameObject food;
    public GameObject currentSpawnedFood;

    // Start is called before the first frame update
    void Start()
    {
        //Spawns in a food at start and sets that food to currentSpawnedFood
        //Adds a listener onto that food for when it is grabbed
        currentSpawnedFood = Instantiate(food, transform.position, transform.rotation);
        currentSpawnedFood.GetComponent<XRGrabInteractable>().firstSelectEntered.AddListener(SpawnFood);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFood(SelectEnterEventArgs selectFood)
    {
        //When food is grabbed, unsubscribe to the one that was grabbed
        //Spawns in new food and sets it to currentSpawnedFood
        //Adds listener to the newly spawned food
        currentSpawnedFood.GetComponent<XRGrabInteractable>().firstSelectEntered.RemoveListener(SpawnFood);
        currentSpawnedFood = Instantiate(food, transform.position, transform.rotation);
        currentSpawnedFood.GetComponent<XRGrabInteractable>().firstSelectEntered.AddListener(SpawnFood);
    }
}
