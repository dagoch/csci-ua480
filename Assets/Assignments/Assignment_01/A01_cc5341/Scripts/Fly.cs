using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> e9caa95ec2510d80f2ad3f48fd1ede1179f85592
=======

>>>>>>> master
namespace A01_cc5341
{
    public class Fly : MonoBehaviour
    {


        // Use this for initialization
        void Start()
        {
        }
        int count = 0;
        // Update is called once per frame
        void Update()
        {
            if (count < 30)
            {
                if (count % 2 == 0)
                {
                    transform.Rotate(Vector3.right * 1);
                }
                count++;
            }
            transform.localPosition = new Vector3(0, Time.time * 3, Time.time *3);

        }
    }
}