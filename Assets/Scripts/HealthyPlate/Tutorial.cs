using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class Tutorial : NetworkBehaviour
{
    [Serializable]
    public class AudioEntry
    {
        public string key; // Identifier for the audio clip
        public AudioClip value; // Reference to the AudioClip
    }

    public bool grabStepCompleted;
    public bool knifeStepCompleted;
    public bool panStepCompleted;
    public bool fryerStepCompleted;
    public int cutCount;
    public int searedCount;
    public int fryCount;
    public XRSimpleInteractable bell;
    public bool isTutorialOngoing;
    public AudioSource audioSource;
    public List<AudioEntry> audioEntries = new List<AudioEntry>(); // List of audio entries
    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

    public void Start()
    {
        // Populate the dictionary for quick lookup
        foreach (var entry in audioEntries)
        {
            if (!audioClipDict.ContainsKey(entry.key))
            {
                audioClipDict.Add(entry.key, entry.value);
            }
            else
            {
                Debug.LogWarning($"Duplicate key found: {entry.key}. Only the first entry will be used.");
            }
        }
    }

    public void PlayAudio(string key)
    {
        if (audioClipDict.TryGetValue(key, out AudioClip clip))
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.Log($"Audio clip with key '{key}' not found.");
        }
    }

    public void StartTutorial()
    {
        if (!isTutorialOngoing)
        {
            Debug.Log("Welcome to Game");
            //Press button
            //Use UI to give overview of game and talk about what to do
            Debug.Log("Start with grabbing a food");
            NetworkedGrab.OnObjectGrabbedStatic.AddListener(ObjectGrabbedStep);
            isTutorialOngoing = true;
            PlayAudio("StartTutorial");
        }
    }

    public void ObjectGrabbedStep(GameObject gameObject, bool grabbed)
    {
        Debug.Log("Grabbing Done");
        grabStepCompleted = true;
        // Wait 3 seconds with confetti
        Debug.Log("Grab a knife and try cutting a food");
        //Highlight around all cuttable foods and knife
        NetworkedGrab.OnObjectGrabbedStatic.RemoveListener(ObjectGrabbedStep);
        ChefKnife.onFoodCutStatic.AddListener(KnifeCutStep);
        PlayAudio("ObjectGrabbedStep");
    }

    public void KnifeCutStep()
    {
        if (cutCount >= 4)
        {
            Debug.Log("Cutting Done");
            knifeStepCompleted = true;
            //Wait 3 seconds with confetti
            Debug.Log("Grab a pan and put it on the stove");
            //Highlight pan and searable foods
            ChefKnife.onFoodCutStatic.RemoveListener(KnifeCutStep);
            ChefPan.onCookwareEnabledStatic.AddListener(PreSearingStep);
            ChefPan.onCookwareDisabledStatic.AddListener(RemovedFromStove);
            PlayAudio("KnifeCutStep2");
        }
        else
        {
            cutCount++;
            Debug.Log("Great Job!" + cutCount + "/5");
            PlayAudio("KnifeCutStep1");
        }
    }

    public void PreSearingStep()
    {
        Debug.Log("Try searing a food on the pan now");
        ChefPan.onCookwareEnabledStatic.RemoveListener(PreSearingStep);
        ChefPan.onCookingIngredientCompleteStatic.AddListener(SearingStep);
        PlayAudio("PreSearingStep");
    }

    public void RemovedFromStove()
    {
        Debug.Log("Make sure the pan stays on the stove to keep the food cooking");
        PlayAudio("RemovedFromStove");
    }

    public void SearingStep()
    {
        if (searedCount >= 2)
        {
            Debug.Log("Searing Done");
            panStepCompleted = true;
            //Wait 3 seconds with confetti
            Debug.Log("Now place the fryer in the frying station");
            //Highlight fryer and fryable foods
            ChefPan.onCookingIngredientCompleteStatic.RemoveListener(SearingStep);
            ChefPan.onCookwareDisabledStatic.RemoveListener(RemovedFromStove);
            ChefFryer.onCookwareEnabledStatic.AddListener(PreFryingStep);
            ChefFryer.onCookwareDisabledStatic.AddListener(RemovedFromFryer);
            PlayAudio("SearingStep2");
        }
        else
        {
            searedCount++;
            Debug.Log("Great Job!" + searedCount + "/3");
            PlayAudio("SearingStep1");
        }
    }

    public void PreFryingStep()
    {
        Debug.Log("Try frying a food in the fryer now");
        ChefFryer.onCookwareEnabledStatic.RemoveListener(PreFryingStep);
        ChefFryer.onCookingIngredientCompleteStatic.AddListener(FryStep);
        PlayAudio("PreFryingStep");
    }

    public void RemovedFromFryer()
    {
        Debug.Log("Make sure to keep the fryer in the oil so the food fries");
        PlayAudio("RemovedFromFryer");
    }

    public void FryStep()
    {
        if (fryCount >= 2)
        {
            Debug.Log("Frying Done");
            fryerStepCompleted = true;
            //Wait 3 seconds with confetti
            Debug.Log("Now hit the bell to start a recipe");
            //Highlight bell
            ChefFryer.onCookingIngredientCompleteStatic.RemoveListener(FryStep);
            ChefFryer.onCookwareDisabledStatic.RemoveListener(RemovedFromFryer);
            bell.selectEntered.AddListener(Bell);
            PlayAudio("FryStep2");
        }
        else
        {
            fryCount++;
            Debug.Log("Great Job!" + fryCount + "/3");
            PlayAudio("FryStep1");
        }
    }

    public void Bell(SelectEnterEventArgs args)
    {
        bell.selectEntered.RemoveListener(Bell);
        //Start test recipe
        isTutorialOngoing = false;
    }
}
