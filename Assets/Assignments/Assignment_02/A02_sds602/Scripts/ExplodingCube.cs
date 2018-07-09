using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sds602.A02
{
    public class ExplodingCube : MonoBehaviour
    {

        public GameObject box;
        public float throwSpeed = 10;
        float speed = 0;
        float position = 0;

        //instantiates cubes as long as space is pressed
        void Update()
        {
            speed = Mathf.Lerp(speed, 0, Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject obj = Instantiate(box, transform.position, transform.rotation);
                speed = throwSpeed;
                obj.transform.Translate(Vector3.forward * speed); //pop the cube up

            }
        }



    }
}