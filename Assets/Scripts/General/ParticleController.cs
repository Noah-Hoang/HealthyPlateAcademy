using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ParticleController : MonoBehaviour
{

    public XRIDefaultInputActions inputActions;
    public bool playParticleEffect;
    public bool allowSpaceDebug;

    public UnityEvent onParticleStateChanged;

    // Start is called before the first frame update
    public virtual void OnEnable()
    {   
        //Setting up the InputActionAsset for use
        inputActions = new XRIDefaultInputActions();
        inputActions.General.Enable();
        inputActions.General.Test.started += TestButton;
        onParticleStateChanged.AddListener(ParticlePlayer);
    }

    public virtual void OnDisable()
    {
        inputActions.General.Test.started -= TestButton;
        onParticleStateChanged.RemoveListener(ParticlePlayer);
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
            ChangeParticleState();
        }       
    }

    public void ChangeParticleState()
    {
        onParticleStateChanged.Invoke();
    }

    public void ParticlePlayer()
    {
        // Ensures that each button press starts the particle effect from the beginning
        playParticleEffect = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            // Gets the particle system from the children
            ParticleSystem particle = transform.GetChild(i).GetComponent<ParticleSystem>();

            // Checks if the child has a particle system attached
            if (particle == null)
            {
                continue;
            }

            if (playParticleEffect)
            {
                particle.Stop();  // Stop it first to ensure it restarts from the beginning
                particle.Play();  // Play the particle effect
            }
        }
    }

}

