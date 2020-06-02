using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHAM_TripodNew : MonoBehaviour
{
    public int score;
    public bool successfulActivationTri;
    private string lastTrigger;
    private GameObject LastHolderTouched;
    public Text scoreHUD;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Holder") && other.gameObject.GetComponent<Holder>().isActivated() )
        {
            
                successfulActivationTri = true;
            
        }
        // Reset if object hits floor
        if (other.gameObject.name == "Floor")
        {
            PHAM_ManagerPro.ColorHolder();
        }
    }

    public bool defSuccess() 
    {
        successfulActivationTri = false;
        return successfulActivationTri;


    }
    public bool success()
    {
        return successfulActivationTri;
    }


}
