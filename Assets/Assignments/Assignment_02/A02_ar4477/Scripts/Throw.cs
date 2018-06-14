using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A02 
{
    public class Throw : MonoBehaviour
    {
        // decalre variables
        public GameObject bballPrefab;
        public Transform player;
        public float ballspeed;
        public float speedx;
        public float speedy;

		private void Start()
		{
            // set speeds
            speedx = 10.0f;
            speedy = 10.0f;
            ballspeed = 15000f;
		}

		void Update()
        {
            // determine x and y based on position
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * speedx;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * speedy;


            // throw ball if space bar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }


        void Shoot()
        {
            // instantiate a basketball 
            GameObject bball = Instantiate(bballPrefab, player.position, player.rotation) as GameObject;

            // put ball 28 units in the air 
            bball.transform.Translate(0,28,0);

            // move the ball forward
            bball.GetComponent<Rigidbody>().AddForce(transform.forward * ballspeed);

            // destroy the ball after 6 seconds
            Destroy(bball, 6.0f);
        }

    }
}
