﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHAM_ManagerPro : MonoBehaviour
{
    private static GameObject[] vholders;
    private static GameObject[] hholders;
    public static int[] tasks;
    private static int current_task_indx;
    public static PHAM_ManagerPro instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        vholders = new GameObject[6];
        hholders = new GameObject[6];
        int vcounter = 0;
        int hcounter = 0;

        //Add all the available vertical holders to the manager
        for (int i = 8; i < 14; i++)
        {
            if (gameObject.transform.GetChild(i).name.Contains("VHolder"))
            {
                vholders[vcounter] = gameObject.transform.GetChild(i).gameObject;
                vcounter++;
            }
        }
        Debug.Log(vcounter);
        //Add all the available horizontal holders to the manager
        for (int i = 2; i < 8; i++)
        {
            if (gameObject.transform.GetChild(i).name.Contains("HHolder"))
            {
                hholders[hcounter] = gameObject.transform.GetChild(i).gameObject;
                hcounter++;
            }
        }
        Debug.Log(hcounter);

        nextTask();
    }

    public static void ColorHolder()
    {


        Vector3 inst_pos = new Vector3(0, 0, 0);
        int judge = Random.Range(0,2);
        int initial = Random.Range(0, 6);
        int target = Random.Range(0, 6);
        if (judge==1)
        {
            //Clear the colors of all holders
            hholders[0].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[1].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[2].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[3].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[4].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[5].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[0].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[1].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[2].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[3].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[4].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[5].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);



            inst_pos = hholders[initial].transform.position;
            GameObject.Find("CylinderPrimitive").transform.rotation = Quaternion.Euler(0, 0, 90);
            GameObject.Find("Card").transform.rotation = Quaternion.Euler(0, 0, 90);
            GameObject.Find("Stick").transform.rotation = Quaternion.Euler(0, 0, 90);
            GameObject.Find("Tripod").transform.rotation = Quaternion.Euler(90, 0, 30);
            GameObject.Find("CylinderPrimitive").transform.position = inst_pos + new Vector3(0, 0, -.75f);
            GameObject.Find("Card").transform.position = inst_pos + new Vector3(.8795f, -.038f, -.8f);
            GameObject.Find("Stick").transform.position = inst_pos + new Vector3(-.5885f, .251f, -.431f);
            GameObject.Find("Tripod").transform.position = inst_pos + new Vector3(.8095f, .656f, -.456f);
            vholders[target].GetComponent<Renderer>().material.color = new Color(.8f, .03f, .02f);
            vholders[target].GetComponent<Holder>().activate();

        }
        else {

            //Clear the colors of all holders
            hholders[0].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[1].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[2].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[3].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[4].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            hholders[5].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[0].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[1].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[2].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[3].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[4].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);
            vholders[5].GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f);


            inst_pos = vholders[initial].transform.position;
            GameObject.Find("CylinderPrimitive").transform.rotation = Quaternion.Euler(0, 0, 0);
            GameObject.Find("Card").transform.rotation = Quaternion.Euler(0, 0, 0);
            GameObject.Find("Stick").transform.rotation = Quaternion.Euler(0, 0, 0);
            GameObject.Find("Tripod").transform.rotation = Quaternion.Euler(0, 90, 90);
            GameObject.Find("CylinderPrimitive").transform.position = inst_pos + new Vector3(0, 0, -.5f);
            GameObject.Find("Card").transform.position = inst_pos + new Vector3(0, .8325f, -.777f);
            GameObject.Find("Stick").transform.position = inst_pos + new Vector3(0, -.8425f, -.881f);
            GameObject.Find("Tripod").transform.position = inst_pos + new Vector3(.258f,1.0945f, -.767f);
            hholders[target].GetComponent<Renderer>().material.color = new Color(.8f, .03f, .02f);
            hholders[target].GetComponent<Holder>().activate();




        }
    }
    public static void nextTask()
    {
        //current_task_indx++;
        ColorHolder();
    }

}
