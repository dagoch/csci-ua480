using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01zs967
{
    public class rotate : MonoBehaviour
    {

        // properties
        // Transform transform
        // GameObject gameObject
        public float speed = 10.0f;

        // Use this for initialization
        void start()
        {

        }

        // Update is called once per frame
        void update()
        {

            //Debug.Log(transform.eulerAngles);

            // calculate rotation for each frame
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
