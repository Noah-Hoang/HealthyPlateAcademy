using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkedGrab : NetworkBehaviour, IStateAuthorityChanged
{
    [Networked, OnChangedRender(nameof(OnHeldChanged))]
    public bool onHeld { get; set; }
    public XRGrabInteractable interactable;

    public void OnHeldChanged()
    {
        if (Object.HasStateAuthority)
        {
            return;
        }
        if (onHeld == true)
        {
            interactable.enabled = false;
        }
        else if (onHeld == false)
        {
            interactable.enabled = true;
        }
    }

    public void StateAuthorityChanged()
    {
        Debug.Log("State Authority Changed to " + Runner.LocalPlayer.PlayerId);
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
