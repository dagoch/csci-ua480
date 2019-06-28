using UnityEngine;
using System.Collections;


namespace A04_jvw242
{
    public class MouseControl : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame

        #region Update
        void Update()
        {

            //Rotate Camera to LEFT side of container
            if (Input.GetKeyDown("q"))
            {
                //Will need to check to see what position camera is in.  
                //if MainCamera Xpos is >= _CameraCenterXPos{
                //MainCamera.Transform = 
                //Else MainCamera.Transform = CenterCameraXPos
                //        This should act as a TOGGLE, not a push and hold.

                //    Left side of cube will need renderer.enabled = false
                //    renderer.enabled = true when left and center.

            }

            //Rotate Camera to RIGHT side of container

            if (Input.GetKeyDown("e"))
            {
                // This key should operate the opposite of the Q button
                //
                //
                //            This will act as a camera TOGGLE not a push and hold.
                //
                //
                // Right side of cube will need renderer.enabled = false when on right
                //renderer.enabled = true when left and center.


            }


            if (Input.GetMouseButton(0))
            { // if 1

                ConstraintsSetZRotate();

                if (Input.GetKeyDown("w"))
                {
                    //Code to control when W is pressed

                    ConstraintsSetZon();
                    Debug.Log("W was pressed");
                } //end W KeyDown Code


                if (Input.GetKeyUp("w"))
                {
                    //Code to reset values changed by W

                    ConstraintsSetZRotate();
                    Debug.Log("W was released");
                }  // end W Keyup code                    

                if (Input.GetKeyDown("left shift"))
                {
                    //Code to control when Shift is pressed

                    ConstraintsEnableRotateOnly();
                    Debug.Log("Left Shift Pressed");
                }    //end Shift Keydown code

                if (Input.GetKeyUp("left shift"))
                {
                    //Code to reset values changed by Shift

                    ConstraintsSetZRotate();
                    Debug.Log("Left Shift Released");
                } //end Shift Keyup Code


            } // End MouseDown event

            if (Input.GetMouseButtonUp(0))
            {

                ConstraintsZonly();

            }


        } // End Update
        #endregion

        public Transform _target;

        private void ConstraintsSetZRotate()
        {
            //Sets All Rotation and Z axis to disabled.
            _target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        }

        private void ConstraintsSetZon()
        {
            //Disable all positions except Z
            _target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        }

        private void ConstraintsEnableRotateOnly()
        {
            //Disable all Positions Enable Only Rotations

            _target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        }

        private void ConstraintsZonly()
        {

            _target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;

        }
    }
}