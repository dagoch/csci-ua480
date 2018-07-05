using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A04
{
    // this script is attached to the player
    public class MoveForward : MonoBehaviour
    {

        public float speed;
        // RaycastHit is used to make a invisible line from reticle to plane
        RaycastHit pos;
        private float currentSpeed = 0.0f;

        // Use this for initialization
        void Start()
        {
            // starting speed
            speed = 3f;
        }

        // Update is called once per frame
        void Update()
        {
            // if the reticle does not intersect the plane within 10 meters, move directly forward
            if (Input.GetMouseButton(0) && !(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out pos, 10)))
            {
                // check if user is going at max speed
                if (currentSpeed < 30.0f)
                {
                    // accelerate to max speed by increasing speed by .025 of current speed every update
                    currentSpeed = currentSpeed + (.025f * speed);
                }
            }
            else
            {
                // decelerate by decreasing speed by .025 of current speed if the player is still moving
                // but button is not pressed
                if (currentSpeed > 0.0f)
                {
                    currentSpeed = currentSpeed - (.025f * speed);

                }
                else
                {
                    // set speed to 0 once user has slowed down enough
                    currentSpeed = 0;

                }
            }
            // create Vector3 in forward direction
            Vector3 forward = Camera.main.transform.forward;
            // keep y position ths same
            forward.y = 0;
            // move forward at whatever speed is determined based on if user is 
            // accelerating (increasing speed) or deccelerating (slowing down)
            transform.Translate(forward * currentSpeed * Time.deltaTime);
        }
    } 
}

