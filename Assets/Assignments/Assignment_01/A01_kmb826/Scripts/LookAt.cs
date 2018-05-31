using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826
{
    public class LookAt : MonoBehaviour
    {

        public Transform ball;

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(ball);
        }
    }
}
