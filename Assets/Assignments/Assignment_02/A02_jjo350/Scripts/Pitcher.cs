using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02jjo350 {
    public class Pitcher : MonoBehaviour
    {
        public GameObject baseball;
        private bool firing = false;
        public float strength = 10.0f;
        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetAxis("Fire1") > 0) {
                GameObject ball = Instantiate(baseball, Camera.main.transform.position, Quaternion.identity);
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                Quaternion rotation = transform.rotation;
                Vector3 dir = rotation * Vector3.forward;
                if (!firing) {
                    firing = true;
                    rb.AddForce(dir * strength);
                }
            } else {
                firing = false;
            }
        }
    }

}
