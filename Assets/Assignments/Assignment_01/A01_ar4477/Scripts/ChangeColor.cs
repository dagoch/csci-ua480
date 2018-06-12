using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A01 
{
    public class ChangeColor : MonoBehaviour
    {
        Renderer r;

        void Start()
        {
            // Based on Unity Documentation
            r = transform.GetComponent<Renderer>();

        }

        void Update()
        {
            // change color based on x or z position of each cube
            if ((transform.localPosition.x > 3 && transform.localPosition.x < 6) || (transform.localPosition.z > 3 && transform.localPosition.z < 6)
                || (transform.localPosition.x < -3 && transform.localPosition.x > -6) || (transform.localPosition.z < -3 && transform.localPosition.z > -6)) {
                r.material.color = new Color(38 / 255.0f, 112 / 255.0f, 231 / 255.0f);
            }
            else {
                r.material.color = new Color(255 / 255.0f, 0 / 12.0f, 0 / 5.0f);
            }

        }
    }
}

