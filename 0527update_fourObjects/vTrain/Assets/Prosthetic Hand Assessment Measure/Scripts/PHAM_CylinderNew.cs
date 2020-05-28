﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHAM_CylinderNew : MonoBehaviour
{
    public int triggerCount, score;
    public bool successfulActivationCld;
    private string lastTrigger;
    private GameObject LastHolderTouched;
    public Text scoreHUD;

    void OnTriggerEnter(Collider other)
    {
        //Upon hitting one of the PHAM ends, add to trigger count
        if (other.gameObject.name.Contains("Holder") && other.gameObject.GetComponent<Holder>().isActivated())
        {
            //Failsafe incase cylinder glitches into the trigger space of another holder
            if (!successfulActivationCld)
            {
                lastTrigger = other.gameObject.name;
                triggerCount++;
            }

            //If both ends are touched, turn the holder to green and activate another PHAM holder
            if (triggerCount == 2)
            {
                successfulActivationCld = true;
                score++;
            }
        }
        // Reset if object hits floor
        if (other.gameObject.name == "Floor")
        {
            PHAM_ManagerPro.ColorHolder();
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Upon exiting one of the PHAM ends, lower to trigger count
        if (other.gameObject.name == lastTrigger && other.gameObject.GetComponent<Holder>().isActivated())
        {
            //Change the color back to normal
            if (triggerCount == 2)
            {
                successfulActivationCld = false;
            }

            triggerCount--;

            //Deactivate the holder if object has left the holder, and deactivate the failsafe boolean
            if (triggerCount == 0 && successfulActivationCld)
            {
                other.gameObject.GetComponent<Holder>().deactivate();
                successfulActivationCld = false;
            }
        }
    }
    public bool success()
    {
        return successfulActivationCld;
    }


}
