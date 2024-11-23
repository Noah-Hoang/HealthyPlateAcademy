using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;

public class Tutorial : NetworkBehaviour
{
    public bool grabStepCompleted;
    public NetworkedGrab networkedGrab;
    public bool knifeStepCompleted;
    public ChefKnife chefKnife;
    public bool panStepCompleted;
    public ChefPan chefPan;
    public bool fryerStepCompleted;
    public ChefFryer chefFryer;
    public int cutCount;
    public int searedCount;
    public int fryCount;
    public XRSimpleInteractable bell;



    public void OnEnable()
    {
        networkedGrab.OnObjectGrabbed.AddListener(ObjectGrabbedStep);
        chefKnife.onFoodCut.AddListener(KnifeCutStep);
        chefPan.onCookingFoodComplete.AddListener(SearingStep);
        chefFryer.onCookingFoodComplete.AddListener(FryStep);
        bell.selectEntered.AddListener(Bell);
    }

    public void OnDisable()
    {
        networkedGrab.OnObjectGrabbed.RemoveListener(ObjectGrabbedStep);
        chefKnife.onFoodCut.RemoveListener(KnifeCutStep);
        chefPan.onCookingFoodComplete.RemoveListener(SearingStep);
        chefFryer.onCookingFoodComplete.RemoveListener(FryStep);
        bell.selectEntered.RemoveListener(Bell);
    }

    public override void Spawned()
    {
        base.Spawned();
        Debug.Log("Welcome to Game");
        Debug.Log("Press button to continue");
        //Press button
        TutorialIntro();
    }

    public void TutorialIntro()
    {
        //Use UI to give overview of game and talk about what to do
        Debug.Log("Start with grabbing a food");
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
                return;
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
                return;
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
                return;
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
        //Start test recipe
    }

    
}
