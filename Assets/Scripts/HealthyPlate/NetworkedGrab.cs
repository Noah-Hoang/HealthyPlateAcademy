using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using UnityEditor.Hardware;

public class NetworkedGrab : NetworkBehaviour, IStateAuthorityChanged
{
    [Networked, OnChangedRender(nameof(ChangeInteractable))]
    public bool onHeld { get; set; }
    public bool isLeftHandHeld;
    public bool destroyOnRelease;
    public float destroyTime;
    public XRGrabInteractable interactable;

    public UnityEvent<GameObject, bool> OnObjectGrabbed = new UnityEvent<GameObject, bool>();
    public UnityEvent<GameObject, bool> OnObjectReleased = new UnityEvent<GameObject, bool>();
    public static UnityEvent<GameObject, bool> OnObjectGrabbedStatic = new UnityEvent<GameObject, bool>();
    public static UnityEvent<GameObject, bool> OnObjectReleasedStatic = new UnityEvent<GameObject, bool>();

    //If you don't have state authority over the object, you get it and returns out of the method
    public void OnGrab(SelectEnterEventArgs enter)
    {
        if (enter.interactorObject.transform.parent.name == "Left Controller")
        {
            isLeftHandHeld = true;
        }
        else
        {
            isLeftHandHeld = false;
        }

        if (!Object.HasStateAuthority)
        {
            Object.RequestStateAuthority();
            return;
        }

        OnHeldChangedRPC(true);

        // Stops timer
        StopAllCoroutines();

        OnObjectGrabbed.Invoke(gameObject, isLeftHandHeld);
        OnObjectGrabbedStatic.Invoke(gameObject, isLeftHandHeld);
    }

    //Is called when state authority is changed and calls the two methods inside
    public void StateAuthorityChanged()
    {
        Debug.Log("State Authority Changed to " + Runner.LocalPlayer.PlayerId);

        OnHeldChangedRPC(true);

        OnObjectGrabbed.Invoke(gameObject, isLeftHandHeld);
        OnObjectGrabbedStatic.Invoke(gameObject, isLeftHandHeld);
    }

    //Is called when object is released and sets the onHeld variable to false
    public void OnRelease()
    {
        OnHeldChangedRPC(false);

        if (destroyOnRelease)
        {
            StartCoroutine(WaitForDestroy());
        }

        OnObjectReleased.Invoke(gameObject, isLeftHandHeld);
        OnObjectReleasedStatic.Invoke(gameObject, isLeftHandHeld);
    }

    public IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(destroyTime);

        // Destroy object
        DestroyRPC();
    }

    //Determines the value of the onHeld variable
    [Rpc]
    public void DestroyRPC()
    {
        if (Object.HasStateAuthority)
        {
            Runner.Despawn(gameObject.transform.root.GetComponent<NetworkObject>());
        }
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
