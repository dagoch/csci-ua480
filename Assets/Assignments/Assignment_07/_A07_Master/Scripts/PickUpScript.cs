using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace A07Examples
{
    public class PickUpScript : NetworkBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;

//        GameObject thingHolderPrefab;
        public GameObject thing;
        public MoveMe thingMoveScript;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();

        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            thingMoveScript = thing.GetComponent<MoveMe>();
        }

        // Update is called once per frame
        public void FixedUpdate()
        {
            CmdMoveThing();
        }

        [Command]
        public void CmdMoveThing()
        {
            thingMoveScript.Move(transform.position);
        }

        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it

                transform.parent = null;  // release the object
                grabbed = false;
//                myRb.isKinematic = false;  //    .useGravity = true;
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camera
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
 //               myRb.isKinematic = true; //  .useGravity = false;

            }

        }
    }
}