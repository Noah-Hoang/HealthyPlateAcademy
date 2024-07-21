using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class Scoreboard : NetworkBehaviour
{
    public GameObject ballPrefab;
    public TMP_Text scoreText;

    private void OnTriggerEnter(Collider other)
    {
        if (HasStateAuthority)
        {
            networkedScore += 1;
            Runner.Despawn(other.gameObject.GetComponent<NetworkObject>());
            Runner.Spawn(ballPrefab, Vector3.zero, Quaternion.identity);
        }
    }


    // Define the networked variable with a callback
    [Networked, OnChangedRender(nameof(OnScoreChanged))]
    public int networkedScore { get; set; }

    // The callback method that gets called when the variable changes
    private void OnScoreChanged()
    {
        Debug.Log("Score changed to: " + networkedScore);
        scoreText.text = networkedScore.ToString();
    }
}
