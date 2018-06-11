using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01_cc5341
{
    public class Top_Propeller_Spin : MonoBehaviour
    {

        void Start()
        {

        }

        void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 350.0f);
        }
    }
}