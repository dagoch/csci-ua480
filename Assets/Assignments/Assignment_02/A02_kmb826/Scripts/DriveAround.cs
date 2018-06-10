using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826_assignment02
{
    public class DriveAround : MonoBehaviour
    {
        private readonly float speed = 5.0f;
        private readonly float pwr = 3.0f;
        public static bool is_driving = false;

        private void Start()
        {
            CharacterController control = GetComponent<CharacterController>();
        }

        void FixedUpdate()
        {

            //Turn vehicle to the left by pressing 'A' key
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up * -speed);
                is_driving = true;
            }

            //Turn vehicle to the right by pressing 'D' key
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * speed);
                is_driving = true;
            }

            //Drive vehicle forward by pressing 'W' key
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(transform.InverseTransformDirection(-transform.forward));
                is_driving = true;
            }

            //Drive vehicle in reverse by pressing 'S' key
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(transform.InverseTransformDirection(transform.forward));
                is_driving = true;
            }
            
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb == null || rb.isKinematic)
                return;
            if (hit.moveDirection.y < -0.3f)
                return;

            Vector3 push = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.y);
            rb.velocity = push * pwr;
        }

    }
}
