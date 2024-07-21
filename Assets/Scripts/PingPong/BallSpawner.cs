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
        if (Runner.IsSharedModeMasterClient)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        if (Runner.ActivePlayers.Count() == 2)
        {
            Debug.Log("HELLO" + Runner.LocalPlayer.PlayerId);
            Runner.Spawn(ballPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}