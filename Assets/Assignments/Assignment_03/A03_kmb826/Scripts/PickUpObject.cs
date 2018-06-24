using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826_assignment3 {
    public class PickUpObject : MonoBehaviour
    {
        Rigidbody rb;
        [HideInInspector]
        public static bool selected = false;
        [HideInInspector]
        public static bool move = false;
        [HideInInspector]
        public static bool rotate = false;
        [HideInInspector]
        public static bool second_click = false;
        float last_x, last_z;
        Vector3 last_position;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {

            last_x = transform.position.x; // Keep track of x-position in case object goes "out of bounds"
            last_z = transform.position.z; // Keep track of z-position in case object goes "out of bounds"

            if (transform.position.y < 0)
            {
                rb.position = new Vector3(last_x, 0f, last_z);
            }

        }

        // Lift object
        public void LiftObject()
        {
            if (!selected)
            {
                transform.parent = Camera.main.transform;
                rb.useGravity = false;
                selected = true;
            }
            else
            {
                if (!second_click)
                {
                    second_click = true;
                    transform.parent = null;
                }
                else
                {
                    second_click = false;
                    transform.parent = Camera.main.transform;
                }
            }
        }

        //Drop Object
        public void DropObject()
        {
            transform.parent = null;
            rb.useGravity = true;
            selected = false;
            second_click = false;
        }

        public void OnCollisionEnter(Collision collision)
        {

            if (collision.transform.tag == "Plane")
            {
                DropObject();                
            }
        }
    }
}
