using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pk1329.A01
{
    public class Kick : MonoBehaviour
    {
        public float speed;
        public float maxRotation;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(transform.eulerAngles);

            // calculate rotation for each frame
            transform.rotation = Quaternion.Euler(maxRotation * Mathf.Sin(Time.time * speed), 0f, 0f);
        }
    }
}
