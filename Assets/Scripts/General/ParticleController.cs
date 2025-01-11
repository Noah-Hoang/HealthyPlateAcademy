using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Fusion;

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
    }

    public virtual void OnDisable()
    {
        //inputActions.General.Test.started -= TestButton;
        onParticleEffectStarted.RemoveListener(StartParticleEffectCallback);
        onParticleEffectEnded.RemoveListener(StopParticleEffectCallback);
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

    [Rpc]
    public void StopParticleEffectRPC()
    {
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

