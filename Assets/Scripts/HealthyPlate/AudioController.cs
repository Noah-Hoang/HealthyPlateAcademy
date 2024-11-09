using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AudioController : MonoBehaviour
{

    public UnityEvent onSoundEffectStarted;
    public UnityEvent onSoundEffectEnded;

    public virtual void OnEnable()
    {       
        onSoundEffectStarted.AddListener(StartSoundEffectCallback);
        onSoundEffectEnded.AddListener(StopSoundEffectCallback);
    }

    public virtual void OnDisable()
    {        
        onSoundEffectStarted.RemoveListener(StartSoundEffectCallback);
        onSoundEffectEnded.RemoveListener(StopSoundEffectCallback);
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
        Debug.Log("HELLO1");
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
        Debug.Log("HELLO2");
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
