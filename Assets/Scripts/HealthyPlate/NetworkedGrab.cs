using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkedGrab : NetworkBehaviour, IStateAuthorityChanged
{
    [Networked, OnChangedRender(nameof(OnHeldChanged))]
    public bool onHeld { get; set; }

    public void OnHeldChanged()
    {

    }

    public void StateAuthorityChanged()
    {
        Debug.Log("State Authority Changed to " + Runner.LocalPlayer.PlayerId);
    }

    public void CheckIfHeld()
    {
        if (onHeld)
        {
           //stop from being grabbed by another person   
        }
    }

    public void OnGrab()
    {
        OnHeldChangedRPC(true);
        if (!Object.HasStateAuthority)
        {
            Object.RequestStateAuthority();          
        }
    }

    public void OnRelease()
    {
        OnHeldChangedRPC(false);
    }

    [Rpc]
    public void OnHeldChangedRPC(bool onHeldState)
    {
        onHeld = onHeldState;
    }
}
