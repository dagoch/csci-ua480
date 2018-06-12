using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A01 
{
    public class Move : MonoBehaviour
    {
        public float speed;
        public float height;

        public float xpos1 ;
        public float zpos1;

        public float xpos2;
        public float zpos2;

        public float xpos3;
        public float zpos3;

        public float xpos4;
        public float zpos4;

        bool right1;
        bool left1;

        bool right2;
        bool left2;

        bool right3;
        bool left3;

        bool right4;
        bool left4;

        void Start()
        {
            speed = .2f;
            height = 5;

            xpos1 = -9.5f;
            zpos1 = 9.5f;

            xpos2 = 9.5f;
            zpos2 = 9.5f;

            xpos3 = 9.5f;
            zpos3 = -9.5f;

            xpos4 = -9.5f;
            zpos4 = -9.5f;

            speed = 5.0f;
            height = 3.0f;

            right1 = true;
            right2 = true;
            right3 = true;
            right4 = true;

        }

        void Update()
        {
            
            // update position of cube 1
            if (right1) {
                xpos1 += .2f;
            }
            if (left1) {
                xpos1 -= .2f;
            }

            if (!(xpos1 < 9.5 && xpos1 >= -9.5)) {
                right1 = false;
                left1 = true;
            }
            else if (xpos1 <= -9.5){
                right1 = true;
                left1 = false;
            }

            //update position of cube 2
            if (right2)
            {
                zpos2 -= .2f;

            }
            if (left2)
            {
                zpos2 += .2f;
            }

            if (!(zpos2 <= 9.5 && zpos2 >= -9.5))
            {
                right2 = false;
                left2 = true;
            }
            else if (zpos2 >= 9.5)
            {
                right2 = true;
                left2 = false;
            }

            // update position of cube 3
            if (right3)
            {
                xpos3 -= .2f;
            }
            if (left3)
            {
                xpos3 += .2f;
            }
            if (xpos3 <= -9.5)
            {
                right3 = false;
                left3 = true;
            }
            else if (xpos3 >= 9.5)
            {
                right3 = true;
                left3 = false;
            }

            // update position of cube 4
            if (right4)
            {
                zpos4 += .2f;

            }
            if (left4)
            {
                zpos4 -= .2f;
            }

            if (zpos4 >= 9.5) 
            {
                right4 = false;
                left4 = true;

            }
            else if (zpos4 <= -9.5)
            {
                right4 = true;
                left4 = false;
            }

            // update cubes
            transform.GetChild(0).localPosition = new Vector3(xpos1, Mathf.Sin(Time.time * speed) * height, zpos1);
            transform.GetChild(1).localPosition = new Vector3(xpos2, Mathf.Sin(Time.time * speed) * height, zpos2);
            transform.GetChild(2).localPosition = new Vector3(xpos3, Mathf.Sin(Time.time * speed) * height , zpos3);
            transform.GetChild(3).localPosition = new Vector3(xpos4, Mathf.Sin(Time.time * speed) * height, zpos4);
        }
    }
}
