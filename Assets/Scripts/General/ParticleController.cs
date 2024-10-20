using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ParticleController : MonoBehaviour
{

    public XRIDefaultInputActions inputActions;
    public ParticleSystem particles;
    public bool particlePlaying;
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
        //If and else if are separate; runs through only one of them
        if (particlePlaying)
        {
            particlePlaying = false;
        }
        else if (!particlePlaying)
        {
            particlePlaying = true;
        }

        // transform.childCount is an int, not a list of the children
        for (int i = 0; i < transform.childCount; i++)
        {
            //Gets the particle system from the children
            ParticleSystem particle = transform.GetChild(i).GetComponent<ParticleSystem>();
            //Checks to see if the child has a partcile system on them
            if (particle == null)
            {
                return;
            }

            if (particlePlaying)
            {
                particle.Play();
            }
            else if (!particlePlaying)
            {
                particle.Stop();
            }
        }
    }
}

