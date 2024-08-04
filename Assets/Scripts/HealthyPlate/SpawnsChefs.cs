using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System.Linq;

public class SpawnChef : SimulationBehaviour, IPlayerJoined
{
    public GameObject playerPrefab;
    public List<Transform> spawnPointList;

    public void PlayerJoined(PlayerRef player)
    {
        //Runner.LocalPlayer is always a reference to your computer. player is a reference to whoever's computer joined.
        if (player == Runner.LocalPlayer)
        {
            Transform spawnPoint = spawnPointList[Runner.ActivePlayers.Count() - 1];
            Runner.Spawn(playerPrefab, spawnPoint.position, spawnPoint.rotation, player);
        }
    }
}
