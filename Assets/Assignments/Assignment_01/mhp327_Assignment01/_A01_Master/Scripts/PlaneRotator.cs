using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mhp327_Assignment01
{
    class PlaneRotator : MonoBehaviour
    {

        public float PlaneSpeed;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * PlaneSpeed);
        }
    }
}