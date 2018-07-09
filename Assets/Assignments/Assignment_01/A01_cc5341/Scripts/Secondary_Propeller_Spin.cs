using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A01_cc5341
{
    public class Secondary_Propeller_Spin : MonoBehaviour
    {


        void Start()
        {

        }


        void Update()
        {
            transform.Rotate(Vector3.left * Time.deltaTime * 420.0f);
        }
    }
}