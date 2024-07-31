using Fusion;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject ballPrefab;

    public void PlayerJoined(PlayerRef player)
    {
        // Checks to see that the person running the script owns the server
        if (Runner.IsSharedModeMasterClient)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        //Checks that there are 2 players 
        if (Runner.ActivePlayers.Count() == 2)
        {
            Runner.Spawn(ballPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}