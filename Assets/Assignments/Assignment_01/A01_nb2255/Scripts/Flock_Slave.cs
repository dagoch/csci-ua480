using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class Flock_Slave : MonoBehaviour
    {

        public float repulsion;
        public float speed;

        GameObject master;
        List<GameObject> slaves;

        void setSlaves( List<GameObject> slaves )
        {
            this.slaves = slaves;
        }

        void setMaster( GameObject master )
        {
            this.master = master;
        }

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            /*
            //this gives us the vector from our slave to the master
            Vector3 positionDelta = master.transform.position - transform.position;

            //Debug.Log("positionDelta: " + positionDelta);

            //for each slave in the flock, look at it's distance from me
            for (int i=0; i<slaves.Count; i++)
            {
                Vector3 vecComp = Vector3.Project(positionDelta, slaves[i].transform.position);
                float dist = Vector3.Distance(transform.position, slaves[i].transform.position);
                //then subtract from my current delta, the vector component in the direction of that flock member, but we only want to substract a lot if we are close by (so we try to avoid getting close to other flock members)
                positionDelta -= (vecComp*repulsion) / dist;
            }

            if (positionDelta.magnitude > 1) 
            {
                positionDelta.Normalize();
            }

            positionDelta *= speed;

            transform.position += positionDelta;
            */

            Vector3 positionDelta = master.transform.position - transform.position;

            if (positionDelta.magnitude > 1)
            {
                positionDelta.Normalize();
            }

            positionDelta *= speed*3/4;

            transform.position += positionDelta * Time.deltaTime;

            Vector3 repulse = new Vector3(0, 0, 0);
            for (int i = 0; i < slaves.Count; i++)
            {
                Vector3 direct = slaves[i].transform.position - transform.position;
                float dist = Vector3.Distance(transform.position, slaves[i].transform.position);
                repulse += (-1 * direct) / dist;
            }

            if (repulse.magnitude > 1)
            {
                repulse.Normalize();
            }

            repulse *= repulsion*speed/4;

            transform.position += repulse * Time.deltaTime;
        }
    }
}