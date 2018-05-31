using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pk1329.A01
{
    public class Kick : MonoBehaviour
    {
        public float speed;
        public float maxRotation;
        public float offset;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(transform.eulerAngles);

            // calculate rotation for each frame
            // Quaternion mathematical construct to represent a rotation.
            // you can't assign anything to rotation unless with Quaternion

            transform.rotation = Quaternion.Euler(offset + (maxRotation * Mathf.Sin(Time.time * speed)), 0f, 0f);
                
        }
    }
}
