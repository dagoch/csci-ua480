using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class Flock_Manager : MonoBehaviour
    {

        public GameObject master;
        public GameObject slave;
        public int flockSize;

        List<GameObject> slaves;

        // Use this for initialization
        void Start()
        {
            /*
             * Vector3 A = new Vector3(0, 0, 0);
             * Vector3 B = new Vector3(0, 0, 1);
             * Debug.Log("The distance between " + A + " and " + B + " is " + Vector3.Distance(A, B));
            */
            

            slaves = new List<GameObject>();
            slaves.Add(slave);
            GameObject newSlave = slave;
            for (int i=0; i<flockSize; i++)
            {
                newSlave = Instantiate(newSlave);
                //Debug.Log("new slave's position before translate: " + newSlave.transform.position);
                newSlave.transform.position += new Vector3(Random.value * 4 - 2 , Random.value * 4 - 2, Random.value * 4 - 2);
                //Debug.Log("new slave's position after translate: " + newSlave.transform.position);
                slaves.Add(newSlave);
            }

            for (int i = 0; i < slaves.Count; i++)
            {
                List<GameObject> tempList = new List<GameObject>();
                for (int j = 0; j < slaves.Count; j++)
                {
                    if (j != i)
                    {
                        tempList.Add(slaves[j]);
                    }
                }

                string debugList = "";
                for (int k = 0; k < tempList.Count; k++)
                {
                    debugList += tempList[k].transform.position;
                }
                Debug.Log("This is what the temporary slave list looks like now: " + debugList);

                slaves[i].SendMessage("setSlaves", tempList);
                slaves[i].SendMessage("setMaster", master);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}