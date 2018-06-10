using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sds602.A01
{
    public class RotateY : MonoBehaviour
    {

        float speed = 50.0f;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(new Vector3(0f, speed * Time.deltaTime, 0f));
        }
    }
}