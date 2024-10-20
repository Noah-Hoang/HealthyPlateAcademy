using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{

    public XRIDefaultInputActions inputActions;
    public ParticleSystem particles;
    public bool particlePlaying;

    // Start is called before the first frame update
    public virtual void OnEnable()
    {
        inputActions = new XRIDefaultInputActions();
        inputActions.General.Enable();
        inputActions.General.Test.started += TestButton;
    }

    public virtual void OnDisable()
    {
        inputActions.General.Test.started -= TestButton;
    }
    
    public virtual void TestButton(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (particlePlaying)
            {
                particlePlaying = false;
            }
            else if (!particlePlaying)
            {
                particlePlaying = true;
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                ParticleSystem particle = transform.GetChild(i).GetComponent<ParticleSystem>();
                if(particle == null)
                {
                    return;
                }

                if(particlePlaying)
                {
                    particle.Play();
                    Debug.Log("HELLO1");
                }              
                else if (!particlePlaying)
                {
                    particle.Stop();
                    Debug.Log("HELLO2");
                }                
            }
        }
    }
}
