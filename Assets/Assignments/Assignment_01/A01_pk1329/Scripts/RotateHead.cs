using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pk1329.A01
{
    public class RotateHead : MonoBehaviour
    {
        public GameObject target;
        public float speed;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.RotateAround(target.transform.position, target.transform.forward, speed * Time.deltaTime);
        }
    }
}
