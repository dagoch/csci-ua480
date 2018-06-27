using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A03
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
        public float fixedY = .55f;
        public bool rotating = false;
        public bool translating = false;
        Vector3 lastPosition;
        float offset;


        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
            lastPosition = transform.position;

        }

        // Update is called once per frame
        void Update()
        {
            // make sure the cube doesnt go under the plane
            CheckGround();
            // rotate if user selects that option
            if (rotating)
            {
                Rotate();
            }
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */
        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camera
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.isKinematic = true; //  .useGravity = false;

            }
        }

        // update booleans of which function the user selects in part 2
        public void TranslateSelected() 
        {
            translating = true;
            rotating = false;
        }
        public void RotateSelected() 
        {
            rotating = true;
            translating = false;
        }

        // Check to see when the camera's y position reaches ~1.59, which
        // is when the cube starts to go into the plane.
        // The cube's parent is the camera once it has been grabbed.
        public void CheckGround()
        {
            if (transform.parent != null) 
            {
                if (transform.parent.position.y < 1.59f)
                {
                    // change the cube's y position so it is always on top of the plane
                    transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);
                }
            }
        }

        public void Rotate() 
        {
            // see how much the x position has changed
            offset = transform.position.x - lastPosition.x;
            // set last position to current position for future comparisons
            lastPosition = transform.position;
            // rotate around the y axis in either direction according to user's head movement 
            // and according to offset
            transform.Rotate(0, offset * 25, 0);
        }
    }
}
