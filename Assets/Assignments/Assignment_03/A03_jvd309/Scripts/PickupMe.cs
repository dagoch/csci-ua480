<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
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
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
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
>>>>>>> 0bdfd6359edd452cf1a7a839f46b61c066d4750a


        // Use this for initialization
        void Start()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();

=======
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
>>>>>>> 0bdfd6359edd452cf1a7a839f46b61c066d4750a
=======

            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();

>>>>>>> 03c3b5c8e036f76c8a2bd15dd0d1bcee16162ae1
        }

        // Update is called once per frame
        void Update()
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======

>>>>>>> 03c3b5c8e036f76c8a2bd15dd0d1bcee16162ae1
            if (transform.parent != null && transform.parent.position.y < 1.587) //value that intercepts plane
            {
                Vector3 cur_pos = transform.position;
                Vector3 cur_rot = transform.eulerAngles;
                cur_pos[1] = 0.5f;//Place cube above plane
                transform.position = cur_pos;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z); //restrict rotation to feel more natural

                //Debug.Log(transform.parent.position.y);

                if (grabbed && (downPointer != null))
                {
                    downPointer.DrawLine(transform.position);
                }
<<<<<<< HEAD
            }
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
=======
            if (grabbed && (downPointer != null)) {
                downPointer.DrawLine(transform.position);
=======
>>>>>>> 03c3b5c8e036f76c8a2bd15dd0d1bcee16162ae1
            }
        }


        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
<<<<<<< HEAD
>>>>>>> 0bdfd6359edd452cf1a7a839f46b61c066d4750a
=======

>>>>>>> 03c3b5c8e036f76c8a2bd15dd0d1bcee16162ae1
         */
        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 03c3b5c8e036f76c8a2bd15dd0d1bcee16162ae1
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                strobe.enabled = false;
                if (downPointer != null)
<<<<<<< HEAD
                    downPointer.DontDraw();
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camer
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                strobe.enabled = true;
                strobe.strobeColor = Color.red;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.isKinematic = true; //  .useGravity = false;
            }
        }
    }
}
=======
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                if (downPointer != null)
=======
>>>>>>> 03c3b5c8e036f76c8a2bd15dd0d1bcee16162ae1
                    downPointer.DontDraw();
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camer
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                strobe.enabled = true;
                strobe.strobeColor = Color.red;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.isKinematic = true; //  .useGravity = false;
            }
        }
<<<<<<< HEAD
    }
}
>>>>>>> 0bdfd6359edd452cf1a7a839f46b61c066d4750a
=======
    }
}
                
 
>>>>>>> 03c3b5c8e036f76c8a2bd15dd0d1bcee16162ae1
