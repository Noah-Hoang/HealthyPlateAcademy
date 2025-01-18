using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Fusion;
using Unity.VisualScripting;
using UnityEngine.XR.Interaction.Toolkit;

public class ParticleController : NetworkBehaviour
{

    public XRIDefaultInputActions inputActions;
    public bool playParticleEffect;
    public bool allowSpaceDebug;

    public UnityEvent onParticleEffectStarted;
    public UnityEvent onParticleEffectEnded;

    // Start is called before the first frame update
    public virtual void OnEnable()
    {
        ////Setting up the InputActionAsset for use
        //inputActions = new XRIDefaultInputActions();
        //inputActions.General.Enable();
        //inputActions.General.Test.started += TestButton;
        onParticleEffectStarted.AddListener(StartParticleEffectCallback);
        onParticleEffectEnded.AddListener(StopParticleEffectCallback);
        gameObject.transform.root.GetComponent<XRGrabInteractable>()?.firstSelectEntered.AddListener(StartParticleEffectGrab);
        gameObject.transform.root.GetComponent<XRGrabInteractable>()?.lastSelectExited.AddListener(StopParticleEffectRelease);
    }

    public virtual void OnDisable()
    {
        Debug.Log("HELLO1");
        //inputActions.General.Test.started -= TestButton;
        onParticleEffectStarted.RemoveListener(StartParticleEffectCallback);
        onParticleEffectEnded.RemoveListener(StopParticleEffectCallback);
        gameObject.transform.root.GetComponent<XRGrabInteractable>()?.firstSelectEntered.RemoveListener(StartParticleEffectGrab);
        gameObject.transform.root.GetComponent<XRGrabInteractable>()?.lastSelectExited.RemoveListener(StopParticleEffectRelease);
    }

    private void OnDestroy()
    {
        Debug.Log("HELLO4");
    }
    public virtual void TestButton(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        if (!allowSpaceDebug)
        {
            return;
        }

        //Checks to see if the button set is being pressed
        if (value.started)
        {
            //ChangeParticleState();
        }
    }

    public void StartParticleEffectGrab(SelectEnterEventArgs enter)
    {
        StartParticleEffectRPC();
    }

    [Rpc]
    public void StartParticleEffectRPC()
    {
        StartParticleEffect();
    }

    public void StartParticleEffect()
    {
        onParticleEffectStarted.Invoke();
    }

    public void StartParticleEffectCallback()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // Gets the particle system from the children
            ParticleSystem particle = transform.GetChild(i).GetComponent<ParticleSystem>();

            // Checks if the child has a particle system attached
            if (particle == null)
            {
                continue;
            }    

            particle.Stop();  // Stop it first to ensure it restarts from the beginning                
            particle.Play();  // Play the particle effect 
        }
    }

    public void StopParticleEffectRelease(SelectExitEventArgs enter)
    {
        Debug.Log("HELLO2");
        StopParticleEffectRPC();
    }

    [Rpc]
    public void StopParticleEffectRPC()
    {
        Debug.Log("HELLO3");
        StopParticleEffect();
    }

    public void StopParticleEffect()
    {
        onParticleEffectEnded.Invoke();
    }

    public void StopParticleEffectCallback()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // Gets the particle system from the children
            ParticleSystem particle = transform.GetChild(i).GetComponent<ParticleSystem>();

            // Checks if the child has a particle system attached
            if (particle == null)
            {
                continue;
            }          
            
            particle.Stop();  // Stop it first to ensure it restarts from the beginning
        }
    } 
}

