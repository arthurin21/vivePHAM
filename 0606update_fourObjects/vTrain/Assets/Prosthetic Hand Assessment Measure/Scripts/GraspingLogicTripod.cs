using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraspingLogicTripod : MonoBehaviour
{
    public bool GraspingTripod = true;
    public float norm_diff_tri;
    public int collision;
    private GameObject palm = null;
    private GameObject tripod = null;
    private vMPLMovementArbiter arbiter = null;
    private const float GRASP_DIST_THRESHOLD = 1f;
    private const float GRASP_ANGLE_THRESHOLD = 2f;

    // Use this for initialization
    void Start()
    {
        GraspingTripod = false;
        palm = GameObject.Find("rPalm"); // or Endpoint
        arbiter = GameObject.Find("vMPLMovementArbiter").GetComponent<vMPLMovementArbiter>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("rInd") || other.gameObject.name.Contains("rMid") || other.gameObject.name.Contains("rTh"))
        {
            collision++;
        }

        if (collision >= 3)
        {
            GraspingTripod = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Proximal") || other.gameObject.name.Contains("palm"))
        {

            collision--;

        }

        if (collision == 0)
        {
            GraspingTripod = false;

        }




    }
    // Update is called once per frame
    void Update()
    {
        float[] angles = arbiter.GetRightFingerAngles();

        if (GraspingTripod)
        {
            GetComponent<Rigidbody>().mass = 0.01f;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            gameObject.transform.position = palm.transform.position
                                            - 0.45f * palm.transform.up
                                            - .5f * palm.transform.forward;
         
            gameObject.transform.forward = palm.transform.up;
            norm_diff_tri = 0;

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
            norm_diff_tri = distance.magnitude;
            //arbiter.GetMovementState() == vMPLMovementArbiter.MOVEMENT_STATE_CYLINDER_GRASP
            //&&


            if (angles[1] > 60.0 && angles[5] > 60.0 && angles[9] > 60.0 && angles[13] > 60.0 && angles[18] > 60.0 && angle_diff <= GRASP_ANGLE_THRESHOLD && norm_diff_tri <= GRASP_DIST_THRESHOLD)
            {
                GraspingTripod = true;

            }
        }*/

        if (PHAM_ManagerPro.whichObj() == 4)
        {
            if (!GraspingTripod && GetComponent<PHAM_TripodNew>().success())
            {
                collision = 0;
                PHAM_ManagerPro.nextTask();
                Debug.Log("ahhhh");
            }

            else if (!GraspingTripod && !GetComponent<PHAM_TripodNew>().success())
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
