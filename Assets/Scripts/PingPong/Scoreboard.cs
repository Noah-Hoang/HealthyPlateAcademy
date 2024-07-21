using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Scoreboard : NetworkBehaviour
{
    public GameObject ballPrefab;
    public int localScore;

    // Define the networked variable with a callback
    [Networked]
    public int networkedScore { get; set; }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //// The callback method that gets called when the variable changes
    //private static void OnMyVariableChanged(Changed<MyNetworkedObject> changed)
    //{
    //    // Get the new value
    //    int newValue = changed.Behaviour.MyVariable;
    //    // Implement your custom logic here
    //    Debug.Log($"MyVariable changed to: {newValue}");
    //}

    private void OnTriggerEnter(Collider other)
    {
        localScore += 1;

        if (HasStateAuthority)
        {
            networkedScore += 1;
            Runner.Despawn(ballPrefab.GetComponent<NetworkObject>());
            Runner.Spawn(ballPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
