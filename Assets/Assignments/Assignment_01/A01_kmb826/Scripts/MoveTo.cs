using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826
{
    public class MoveTo : MonoBehaviour
    {

        public GameObject ball;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, ball.transform.position, 3f * Time.deltaTime);
        }
    }
}
