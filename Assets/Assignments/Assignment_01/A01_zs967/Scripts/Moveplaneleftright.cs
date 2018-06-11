using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace A01zs967
{
    public class Moveplaneleftright : MonoBehaviour
    {
        int speed = 10;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x <= -6)
            {
                speed = 5;
            }
            if (transform.position.x >= 6)
            {
                speed = -10;
            }
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}