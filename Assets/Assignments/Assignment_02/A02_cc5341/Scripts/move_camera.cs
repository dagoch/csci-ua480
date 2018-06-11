using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_cc5341
{

    public class move_camera : MonoBehaviour
    {
        float X = 0f;
        float Y = 45f;

        void Start()
        {

        }

        void Update()
        {
            X += 2 * Input.GetAxis("Mouse X");
            Y -= 2 * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(Y, X, 0.0f);
        }
    }
}