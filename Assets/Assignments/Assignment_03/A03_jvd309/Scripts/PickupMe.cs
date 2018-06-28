using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03Examples
{
    /***
     * PickupMe component allows user to select this object and 
     * move it with their gaze
     ******/
    public class PickupMe : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        StrobeSelected strobe;
        public DrawDownPointer downPointer;
        public string cur_mode;
        // Use this for initialization

        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
            cur_mode = "translate";

        }

        // Update is called once per frame
        void Update()
        {
            if (cur_mode == "translate")
            {
                if (transform.parent != null && transform.parent.position.y < 1.587)
                {
                    Vector3 cur_pos = transform.position;
                    Vector3 cur_rot = transform.eulerAngles;
                    cur_pos[1] = 0.5f;
                    transform.position = cur_pos;
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

                }

                //Debug.Log(transform.parent.position.y);
                if (grabbed && (downPointer != null))
                {
                    downPointer.DrawLine(transform.position);
                }
            }
            if (cur_mode == "rotate"){
                transform.parent = Camera.main.transform;
                Vector3 cur_pos = transform.position;
                Vector3 cur_rot = transform.eulerAngles;
                cur_pos[1] = 2;
                transform.rotation = Camera.main.transform.rotation;
            }
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */
        public void ChangeMode(string new_mode){
            Debug.Log(cur_mode);
            if (new_mode != cur_mode){
                cur_mode = new_mode;
            }
        }

        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                if (downPointer != null)
                    downPointer.DontDraw();
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camer
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.isKinematic = true; //  .useGravity = false;
            }
        }
    }
}
