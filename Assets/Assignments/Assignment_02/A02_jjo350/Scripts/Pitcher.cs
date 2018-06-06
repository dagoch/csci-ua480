using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02jjo350 {
    public class Pitcher : MonoBehaviour
    {
        public GameObject baseball;
        public float strength = 10.0f;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetAxis("Fire1") > 0) {
                GameObject ball = Instantiate(baseball, transform.position, Quaternion.identity);
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                Quaternion rotation = Camera.main.transform.rotation;
                Vector3 dir = rotation * Vector3.forward;
                rb.AddForce(dir * strength);
            }
        }
    }

}
