using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace A02_cc5341
{

    public class shoot_ball : MonoBehaviour
    {
        public float speed = 500.0f;

        Rigidbody rb;
        bool shot = false;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.E) && !shot)
            {
                rb.AddForce(Vector3.forward * speed);
                shot = true;
            }
        }
    }

}