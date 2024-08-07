using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkedGrab : NetworkBehaviour, IStateAuthorityChanged
{
    [Networked, OnChangedRender(nameof(ChangeInteractable))]
    public bool onHeld { get; set; }
    public XRGrabInteractable interactable;

    public void OnGrab()
    {
        if (!Object.HasStateAuthority)
        {
            Object.RequestStateAuthority();
        }
        else if (Object.HasStateAuthority)
        {
            ChangeInteractableRPC();
        }

        OnHeldChangedRPC(true);
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

    public void StateAuthorityChanged()
    {
        Debug.Log("State Authority Changed to " + Runner.LocalPlayer.PlayerId);
        
        if (onHeld)
        {
            ChangeInteractableRPC();
        }
    }

    [Rpc]
    public void ChangeInteractableRPC()
    {
        if (Object.HasStateAuthority)
        {
            interactable.enabled = true;
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
    public void ChangeInteractable()
    {
        if (Object.HasStateAuthority)
        {
            interactable.enabled = true;
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
}
