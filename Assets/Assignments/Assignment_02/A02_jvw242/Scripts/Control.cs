using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*Code is taken from Assignment 2 Scripts*/

    /*****
     * BallController
     * Lets user push an object around using keyboard input
     * Based on the Unity Roll-A-Ball Tutorial
     *****/
    public class Control : MonoBehaviour
    {
        // A multiplier to determine how strongly to push the ball
        //  with each key press
        public float speed = 10.0f;

        Rigidbody player;

        // Use this for initialization
        void Start()
        {
            // Get my rigidbody
            player = GetComponent<Rigidbody>();
          
        }

        // FixedUpdate is called once per physics update (a fixed timestep)
        void FixedUpdate()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            //Vector3 pos = this.transform.position;
            
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                Vector3 position = this.transform.position;
                position.x++;
                this.transform.position = position;
                Vector3 direction = new Vector3(moveX,0.0f, moveZ);
                player.AddForce(speed * direction);


            }

            if (Input.GetKeyDown(KeyCode.RightArrow)){
                Vector3 position = this.transform.position;
                position.x--;
                this.transform.position = position;
                Vector3 direction = new Vector3(moveX, 0.0f, moveZ);
                player.AddForce(speed * direction);

                
            }

            if (Input.GetKeyUp(KeyCode.UpArrow)) {
                Vector3 position = this.transform.position;
                position.z++;
                this.transform.position = position;
                Vector3 direction = new Vector3(moveX, 0.0f, moveZ);
                player.AddForce(speed * direction);


            }

            if (Input.GetKeyUp(KeyCode.DownArrow)) {
                Vector3 position = this.transform.position;
                position.z--;
                this.transform.position = position;
                Vector3 direction = new Vector3(moveX, 0.0f, moveZ);
                player.AddForce(speed * direction);

            }                
        }
    }