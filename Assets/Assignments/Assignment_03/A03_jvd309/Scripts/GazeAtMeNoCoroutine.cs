using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jvd309
{
    /***
    * GazeAtMeNoCoroutine
    * Implements basic timer selection of object.
    * Does same as GazeAtMe, but checks for gaze continuously in Update, 
    * instead of using Coroutine.
    ****/
    public class GazeAtMeNoCoroutine : MonoBehaviour
    {
        Rigidbody myRb;
        public Color selectColor = Color.red;
        public float popTime = 2.0f;

        Color initialColor;
        float counter = 0;
        MeshRenderer meshRenderer;
        IEnumerator coroutine;
<<<<<<< HEAD
        PickupMe PickupMe;
        rotateMe RotateMe;
=======
>>>>>>> 0bdfd6359edd452cf1a7a839f46b61c066d4750a

        bool gazeIn = false; // Set on gaze enter, clear on gaze exit

        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            initialColor = meshRenderer.material.color;
<<<<<<< HEAD
            myRb = GetComponent<Rigidbody>();
=======
            myRb = GetComponent<Rigidbody>();

>>>>>>> 0bdfd6359edd452cf1a7a839f46b61c066d4750a
        }


        public void Update()
        {
            if (gazeIn)
            {
                // fade color towards selectColor until popTime has elapsed
<<<<<<< HEAD
=======

                Debug.Log("hi");
>>>>>>> 0bdfd6359edd452cf1a7a839f46b61c066d4750a
                counter += Time.deltaTime;
                meshRenderer.material.color = Color.Lerp(initialColor, selectColor, counter / popTime);

                if (counter > popTime)
<<<<<<< HEAD
                {                  
                    // Start pickup script
                    //Debug.Log("Pickup");

                    //first disable rotate script
                    RotateMe = FindObjectOfType<rotateMe>();
                    RotateMe.enabled = false;

                    //start and initialize pickup of cube
                    PickupMe = FindObjectOfType<PickupMe>();
                    PickupMe.enabled = true;
                    PickupMe.grabbed = false;
                    PickupMe.PickupOrDrop();
                    Reset();
=======
                {                  // Then pop cube.
                    myRb.AddForce(Vector3.up * 300 + Random.insideUnitSphere * .25f);
                    myRb.AddTorque(Random.insideUnitSphere * 10);
                    Reset();

>>>>>>> 0bdfd6359edd452cf1a7a839f46b61c066d4750a
                }
            }
        }

        /***
        * GazeAndPop
        * triggered when gaze intersects with collider
        * **/
        public void GazeAndPop()
        {
<<<<<<< HEAD

            counter = 0;
            gazeIn = true;
        }
=======
            counter = 0;
            gazeIn = true;
        }
>>>>>>> 0bdfd6359edd452cf1a7a839f46b61c066d4750a

        /***
        * Reset
        * Called when gaze stops intersecting collider
        * Resets color and stops timer coroutine
        * **/
		public void Reset()
		{
            meshRenderer.material.color = initialColor;
            counter = 0;
            gazeIn = false;
		}
	}
}
