using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class Scoreboard : NetworkBehaviour
{
    public GameObject ballPrefab;
    public TMP_Text scoreText;

    // Define the networked variable with a callback

    //Things in brackets are attributes
    //They are attached to the variable below it
    //Networked means that the variable is networked. OnChangedRender checks to see if the variable is changed and if it is, calls back to the OnScoreChanged method
    [Networked, OnChangedRender(nameof(OnScoreChanged))]
    public int networkedScore { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        //Refers to the player that started the server and therefore has authority over the thing getting destroyed
        if (HasStateAuthority)
        {
            networkedScore += 1;
        }
        // Checks to see if the player running the script is the person who owns the server
        if (Runner.IsSharedModeMasterClient)
        {
            Runner.Despawn(other.gameObject.GetComponent<NetworkObject>());
            Runner.Spawn(ballPrefab, Vector3.zero, Quaternion.identity);
        }
    }


    // The callback method that gets called when the variable changes
    private void OnScoreChanged()
    {
        Debug.Log("Score changed to: " + networkedScore);
        scoreText.text = networkedScore.ToString();
    }
}
