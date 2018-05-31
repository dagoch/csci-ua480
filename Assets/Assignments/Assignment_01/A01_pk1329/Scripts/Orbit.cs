using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pk1329A01
{
    public class Orbit : MonoBehaviour
    {
        public float speed;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.left * (speed * Time.deltaTime));
        }
    }
}
