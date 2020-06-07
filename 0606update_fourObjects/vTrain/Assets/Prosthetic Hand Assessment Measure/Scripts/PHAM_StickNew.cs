using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHAM_StickNew : MonoBehaviour
{
    public int score;
    public bool successfulActivationStk;
    private string lastTrigger;
    private GameObject LastHolderTouched;
    public Text scoreHUD;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Holder")&&other.gameObject.GetComponent<Holder>().isActivated() )
        {
            //Failsafe incase cylinder glitches into the trigger space of another holder
            successfulActivationStk = true;
        }
        // Reset if object hits floor
        if (other.gameObject.name == "Floor")
        {
            PHAM_ManagerPro.ColorHolder();
        }
    }

    public bool defSuccess()
    {
        successfulActivationStk = false;
        return successfulActivationStk;


    }

    public bool success()
    {
        return successfulActivationStk;
    }



}
