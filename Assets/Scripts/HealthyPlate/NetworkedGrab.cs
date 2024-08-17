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

    //If you don't have state authority over the object, you get it and returns out of the method
    public void OnGrab()
    {
        if (!Object.HasStateAuthority)
        {
            Object.RequestStateAuthority();
            return;
        }
 
        OnHeldChangedRPC(true);
    }

    //Is called when state authority is changed and calls the two methods inside
    public void StateAuthorityChanged()
    {
        Debug.Log("State Authority Changed to " + Runner.LocalPlayer.PlayerId);

        OnHeldChangedRPC(true);
    }

    //Is called when object is released and sets the onHeld variable to false
    public void OnRelease()
    {
        Debug.Log("Hello");
        OnHeldChangedRPC(false);
    }
  
    //Determines the value of the onHeld variable
    [Rpc]
    public void OnHeldChangedRPC(bool onHeldState)
    {
        onHeld = onHeldState;
    }

    //If you have state authority over the object then nothing happens
    //If you do not have state authority over the object, you cannot take the object if it is being held
    //If the object is not held, you can now pick it up
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
