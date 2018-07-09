using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sds602.A01
{

    public class RotateX : MonoBehaviour
    {
        float speed = 50.0f;

		// Update is called once per frame
		void Update()
        {
            transform.Rotate(new Vector3(speed * Time.deltaTime, 0f, 0f));
        }
    }
}