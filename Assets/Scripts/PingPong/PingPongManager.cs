using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongManager : NetworkBehaviour
{
    public int score;
    public GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        score += 1;

        if (HasStateAuthority)
        {

            //Runner.Despawn(ballPrefab);
            Runner.Spawn(ballPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
