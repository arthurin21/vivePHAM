using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHAM_CylinderNew : MonoBehaviour
{
    public int score;
    public bool successfulActivationCld;
    private GameObject LastHolderTouched;
    public Text scoreHUD;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Holder") && other.gameObject.GetComponent<Holder>().isActivated())
        {
            //Failsafe incase cylinder glitches into the trigger space of another holder
            successfulActivationCld = true;
        }
        // Reset if object hits floor
        
        if (other.gameObject.name == "Floor")
        {
            PHAM_ManagerPro.ColorHolder();
        }
    }
    public bool defSuccess()
    {
        successfulActivationCld = false;
        return successfulActivationCld;


    }

    public bool success()
    {
        return successfulActivationCld;
    }


}
