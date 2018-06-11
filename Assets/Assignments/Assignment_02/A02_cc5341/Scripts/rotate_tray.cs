using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_cc5341
{
    public class rotate_tray : MonoBehaviour
    {

        public float rotateSpeed = 10f;

        void Update()
        {

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.back * Time.deltaTime * rotateSpeed);

            if (Input.GetKey(KeyCode.DownArrow))
                transform.Rotate(Vector3.left * Time.deltaTime * rotateSpeed);

            if (Input.GetKey(KeyCode.UpArrow))
                transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);

        }
    }
}