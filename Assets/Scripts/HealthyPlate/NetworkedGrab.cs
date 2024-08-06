using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkedGrab : NetworkBehaviour, IStateAuthorityChanged
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrab()
    {
        if (!Object.HasStateAuthority)
        {
            Object.RequestStateAuthority();
        }
    }

    public void StateAuthorityChanged()
    {
        Debug.Log("State Authority Changed to " + Runner.LocalPlayer.PlayerId);
    }
}
