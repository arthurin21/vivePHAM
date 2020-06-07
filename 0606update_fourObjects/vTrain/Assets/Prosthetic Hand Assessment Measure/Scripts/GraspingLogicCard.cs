using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraspingLogicCard : MonoBehaviour
{
    public bool GraspingCard = true;
    public float norm_diff_crd;
    public int collision;
    private GameObject palm = null;
    private GameObject card = null;
    private vMPLMovementArbiter arbiter = null;
    private const float GRASP_DIST_THRESHOLD = 1f;
    private const float GRASP_ANGLE_THRESHOLD = 2f;

    // Use this for initialization
    void Start()
    {
        GraspingCard = false;
        palm = GameObject.Find("rPalm"); // or Endpoint
        arbiter = GameObject.Find("vMPLMovementArbiter").GetComponent<vMPLMovementArbiter>();
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("rIndProximal") || other.gameObject.name.Contains("rThProximal") || other.gameObject.name.Contains("palm"))
        {
            collision++;
        }

        if (collision >= 3)
        {
            GraspingCard = true;
        }

    }






    void Update()
    {
        float[] angles = arbiter.GetRightFingerAngles();

        if (GraspingCard)
        {
            GetComponent<Rigidbody>().mass = 0.01f;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            gameObject.transform.position = palm.transform.position
                                            - 0.85f * palm.transform.up
                                            - .2f * palm.transform.right;
            gameObject.transform.right = palm.transform.forward;
            norm_diff_crd = 0;
            //if (angles[1] < 60.0 || angles[5] < 60.0 || angles[9] < 60.0 || angles[13] < 60.0 || angles[18] < 60.0 ) {
            //Grasping = false;
            // }
        }
        /*else
        {
            float angle_diff = Mathf.Min(Vector3.Distance(palm.transform.right, -1.0f * gameObject.transform.up),
                                          Vector3.Distance(palm.transform.right, gameObject.transform.up));
            Vector3 distance = palm.transform.position - gameObject.transform.position;

            //            Debug.Log(string.Format("Triggering...{0}, {1}", angle_diff, distance.magnitude));
            norm_diff_crd = distance.magnitude;
            //arbiter.GetMovementState() == vMPLMovementArbiter.MOVEMENT_STATE_CYLINDER_GRASP
            //&&
            

            if (angles[1] > 60.0 && angles[5] > 60.0 && angles[9] > 60.0 && angles[13] > 60.0 && angles[18] > 60.0 && angle_diff <= GRASP_ANGLE_THRESHOLD && norm_diff_crd <= GRASP_DIST_THRESHOLD)
            {
                GraspingCard = true;

            }
        }*/

        if (PHAM_ManagerPro.whichObj() == 2)
        {
            if (!GraspingCard && GetComponent<PHAM_CardNew>().success())
            {
                collision = 0;
                PHAM_ManagerPro.nextTask();
                Debug.Log("ahhhh");
            }

            else if (!GraspingCard && !GetComponent<PHAM_CardNew>().success())
            {
                GetComponent<Rigidbody>().mass = 1;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
        else
        {
            GetComponent<Rigidbody>().mass = 0.01f;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;


        }

    }

}
