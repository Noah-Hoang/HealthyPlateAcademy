using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;

public class Tutorial : NetworkBehaviour
{
    public bool grabStepCompleted;
    public bool knifeStepCompleted;
    public bool panStepCompleted;
    public bool fryerStepCompleted;
    public int cutCount;
    public int searedCount;
    public int fryCount;
    public XRSimpleInteractable bell;

    public void StartTutorial()
    {
        Debug.Log("Welcome to Game");
        //Press button
        //Use UI to give overview of game and talk about what to do
        Debug.Log("Start with grabbing a food");
        NetworkedGrab.OnObjectGrabbedStatic.AddListener(ObjectGrabbedStep);
    }

    public void ObjectGrabbedStep(GameObject gameObject,bool grabbed )
    {
        if (!grabStepCompleted)
        {
            Debug.Log("Grabbing Done");
            grabStepCompleted = true;
            // Wait 3 seconds with confetti
            Debug.Log("Grab a knife and try cutting a food");
            //Highlight around all cuttable foods and knife
            NetworkedGrab.OnObjectGrabbedStatic.RemoveListener(ObjectGrabbedStep);
            ChefKnife.onFoodCutStatic.AddListener(KnifeCutStep);
        }
    }

    public void KnifeCutStep()
    {
        if (grabStepCompleted == true && knifeStepCompleted == false && panStepCompleted == false && fryerStepCompleted == false)
        {
            if (cutCount >= 4)
            {
                Debug.Log("Cutting Done");
                knifeStepCompleted = true;
                //Wait 3 seconds with confetti
                Debug.Log("Grab food and put it on the pan to sear it");
                //Highlight pan and searable foods
                ChefKnife.onFoodCutStatic.RemoveListener(KnifeCutStep);
                ChefPan.onCookingFoodCompleteStatic.AddListener(SearingStep);
            }
            else
            {
                cutCount++;
                Debug.Log("Great Job!" + cutCount +"/5");
            }
        }
    }

    public void SearingStep()
    {
        if (grabStepCompleted == true && knifeStepCompleted == true && panStepCompleted == false && fryerStepCompleted == false)
        {
            if (searedCount >= 4)
            {
                Debug.Log("Searing Done");
                panStepCompleted = true;
                //Wait 3 seconds with confetti
                Debug.Log("Now try to fry some foods");
                //Highlight fryer and fryable foods
                ChefPan.onCookingFoodCompleteStatic.RemoveListener(SearingStep);
                ChefFryer.onCookingFoodCompleteStatic.AddListener(FryStep);
            }
            else
            {
                searedCount++;
                Debug.Log("Great Job!" + searedCount + "/5");
            }
        }
    }

    public void FryStep()
    {
        if (grabStepCompleted == true && knifeStepCompleted == true && panStepCompleted == true && fryerStepCompleted == false)
        {
            if (fryCount >= 4)
            {
                Debug.Log("Frying Done");
                fryerStepCompleted = true;
                //Wait 3 seconds with confetti
                Debug.Log("Now hit the bell to start a recipe");
                //Highlight bell
                ChefFryer.onCookingFoodCompleteStatic.RemoveListener(FryStep);
                bell.selectEntered.AddListener(Bell);
            }
            else
            {
                fryCount++;
                Debug.Log("Great Job!" + fryCount + "/5");
            }
        }
    }

    public void Bell(SelectEnterEventArgs args)
    {
        bell.selectEntered.RemoveListener(Bell);
        //Start test recipe
    }

    
}
