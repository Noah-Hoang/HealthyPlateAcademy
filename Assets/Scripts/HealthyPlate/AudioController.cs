using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioController : MonoBehaviour
{

    public UnityEvent onSoundEffectStarted;
    public UnityEvent onSoundEffectEnded;

    public virtual void OnEnable()
    {       
        onSoundEffectStarted.AddListener(StartSoundEffectCallback);
        onSoundEffectEnded.AddListener(StopSoundEffectCallback);
        gameObject.transform.root.GetComponent<XRGrabInteractable>()?.firstSelectEntered.AddListener(StartSoundEffectGrab);
        gameObject.transform.root.GetComponent<XRGrabInteractable>()?.lastSelectExited.AddListener(StopSoundEffectRelease);
    }

    public virtual void OnDisable()
    {        
        onSoundEffectStarted.RemoveListener(StartSoundEffectCallback);
        onSoundEffectEnded.RemoveListener(StopSoundEffectCallback);
        gameObject.transform.root.GetComponent<XRGrabInteractable>()?.firstSelectEntered.RemoveListener(StartSoundEffectGrab);
        gameObject.transform.root.GetComponent<XRGrabInteractable>()?.lastSelectExited.RemoveListener(StopSoundEffectRelease);
    }

    public void StartSoundEffectGrab(SelectEnterEventArgs enter)
    {
        StartSoundEffectRPC();
    }

    [Rpc]
    public void StartSoundEffectRPC()
    {
        StartSoundEffect();
    }

    public void StartSoundEffect()
    {
        onSoundEffectStarted.Invoke();
    }

    public void StartSoundEffectCallback()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // Gets the soundEffect system from the children
           AudioSource soundEffect = transform.GetChild(i).GetComponent<AudioSource>();

            // Checks if the child has a soundEffect system attached
            if (soundEffect == null)
            {
                continue;
            }

            soundEffect.Stop();  // Stop it first to ensure it restarts from the beginning                
            soundEffect.Play();  // Play the soundEffect effect 
        }
    }

    public void StopSoundEffectRelease(SelectExitEventArgs enter)
    {
        StopSoundEffectRPC();
    }

    [Rpc]
    public void StopSoundEffectRPC()
    {
        StopSoundEffect();
    }

    public void StopSoundEffect()
    {
        onSoundEffectEnded.Invoke();
    }

    public void StopSoundEffectCallback()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // Gets the soundEffect system from the children
            AudioSource soundEffect = transform.GetChild(i).GetComponent<AudioSource>();

            // Checks if the child has a soundEffect system attached
            if (soundEffect == null)
            {
                continue;
            }

            soundEffect.Stop();  // Stop it first to ensure it restarts from the beginning
        }
    }
}
