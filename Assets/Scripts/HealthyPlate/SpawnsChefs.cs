using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System.Linq;

public class SpawnChef : NetworkBehaviour, IPlayerJoined
{
    public GameObject playerPrefab;
    public List<Transform> spawnPointList;

    public override void Spawned()
    {
        base.Spawned();
        //Runner.LocalPlayer is always a reference to your computer. player is a reference to whoever's computer joined.        
        Transform spawnPoint = spawnPointList[Runner.ActivePlayers.Count() - 1];
        Runner.Spawn(playerPrefab, spawnPoint.position, spawnPoint.rotation, Runner.LocalPlayer);        
    }
    public void PlayerJoined(PlayerRef player)
    {
        ////Runner.LocalPlayer is always a reference to your computer. player is a reference to whoever's computer joined.
        //if (player == Runner.LocalPlayer)
        //{
        //    Transform spawnPoint = spawnPointList[Runner.ActivePlayers.Count() - 1];
        //    Runner.Spawn(playerPrefab, spawnPoint.position, spawnPoint.rotation, player);
        //}
    }
}
