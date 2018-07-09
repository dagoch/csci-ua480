using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wmc286
{
    public class SwitchController : MonoBehaviour
    {
        private GameObject wall;
        private const float COLLVAL = 5;
        private bool isAdd = true;

        private void OnTriggerEnter(Collider other)
        {
            Vector3 otherPos = other.transform.position;

            if ((COLLVAL - otherPos.z) <= 1)
            {
                // North
                wall = GameObject.Find("Wall_North");
            }
            else if ((COLLVAL + otherPos.z) <= 1)
            {
                // South
                wall = GameObject.Find("Wall_South");
            }
            else if ((COLLVAL - otherPos.x) <= 1)
            {
                // East
                wall = GameObject.Find("Wall_East");
            }
            else if ((COLLVAL + otherPos.x) <= 1)
            {
                // West
                wall = GameObject.Find("Wall_West");
            }

            Destroy(this.gameObject);
            Destroy(wall, 0.1f);
        }

        private void Update()
        {
            float switchX = this.transform.position.x;
            float switchY = this.transform.position.y;
            float switchZ = this.transform.position.z;
            string switchName = this.name;

            if (switchName.CompareTo("Switch_North") == 0)
            {
                float newXValue;
                if (isAdd)
                {
                    newXValue = switchX + 0.1f;
                    if (newXValue >= 4.5)
                    {
                        isAdd = false;
                    }
                }
                else
                {
                    newXValue = switchX - 0.1f;
                    if (newXValue <= -4.5)
                    {
                        isAdd = true;
                    }
                }
                this.transform.position = new Vector3(newXValue, switchY, switchZ);
            }

            if (switchName.CompareTo("Switch_South") == 0)
            {
                float newXValue;
                if (isAdd)
                {
                    newXValue = switchX - 0.01f;
                    if (newXValue <= -4.5)
                    {
                        isAdd = false;
                    }
                }
                else
                {
                    newXValue = switchX + 0.01f;
                    if (newXValue >= 4.5)
                    {
                        isAdd = true;
                    }
                }
                this.transform.position = new Vector3(newXValue, switchY, switchZ);
            }

            if (switchName.CompareTo("Switch_East") == 0)
            {
                float newZValue;
                if (isAdd)
                {
                    newZValue = switchZ + 0.01f;
                    if (newZValue >= 4.5)
                    {
                        isAdd = false;
                    }
                }
                else
                {
                    newZValue = switchZ - 0.01f;
                    if (newZValue <= -4.5)
                    {
                        isAdd = true;
                    }
                }
                this.transform.position = new Vector3(switchX, switchY, newZValue);
            }

            if (switchName.CompareTo("Switch_West") == 0)
            {
                float newZValue;
                if (isAdd)
                {
                    newZValue = switchZ - 0.1f;
                    if (newZValue <= -4.5)
                    {
                        isAdd = false;
                    }
                }
                else
                {
                    newZValue = switchZ + 0.1f;
                    if (newZValue >= 4.5)
                    {
                        isAdd = true;
                    }
                }
                this.transform.position = new Vector3(switchX, switchY, newZValue);
            }
        }
    }
}