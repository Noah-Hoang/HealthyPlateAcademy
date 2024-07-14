using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System.Linq;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject playerPrefab;

    public void PlayerJoined(PlayerRef player)
    {
        //Runner.LocalPlayer is always a reference to your computer. player is a reference to whoever's computer joined.
        if (player == Runner.LocalPlayer)
        {
            if(Runner.ActivePlayers.Count() == 1)
            {
                Runner.Spawn(playerPrefab, new Vector3(-5, 0, 0), Quaternion.identity, player);
            }
            else if (Runner.ActivePlayers.Count() == 2)
            {
                Runner.Spawn(playerPrefab, new Vector3(5, 0, 0), Quaternion.identity, player);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
