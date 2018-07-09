using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class Slide : MonoBehaviour
    {

        public float offset;
        public float speed;
        public float magnitude;

        bool active;

        // Use this for initialization
        void Start()
        {
            active = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject gOther = other.gameObject;
            if (!gOther.CompareTag("shelf"))
            {
                active = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if( active )
            {
                transform.Translate(new Vector3(Mathf.Sin((Time.time + offset) * speed) * magnitude, 0, 0));
            }
        }
    }
}