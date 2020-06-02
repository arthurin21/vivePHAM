using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHAM_CardNew : MonoBehaviour
{
    public int score;
    public bool successfulActivationCrd;
    private string lastTrigger;
    private GameObject LastHolderTouched;
    public Text scoreHUD;

    void OnTriggerEnter(Collider other)
    {
        //Upon hitting one of the PHAM ends, add to trigger count
        if (other.gameObject.name.Contains("Holder") && other.gameObject.GetComponent<Holder>().isActivated())
        {
            //Failsafe incase cylinder glitches into the trigger space of another holder
            successfulActivationCrd = true;
        }
        // Reset if object hits floor
        if (other.gameObject.name == "Floor")
        {
            PHAM_ManagerPro.ColorHolder();
        }
    }
    public bool defSuccess()
    {
        successfulActivationCrd = false;
        return successfulActivationCrd;


    }

    public bool success()
    {
        return successfulActivationCrd;
    }


}
