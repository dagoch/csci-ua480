using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple script to create a cube explosion when vehicle gets close enough to box
namespace kmb826_assignment02
{
    public class CubeExplosion : MonoBehaviour
    {

        public GameObject truck;
        public GameObject cube;
        private float distance;

        void Update()
        {
            distance = Vector3.Distance(truck.transform.position, transform.position); // check distance between the two objects
            if (distance < 10f)
            {
                Vector3 pos = this.transform.position;
                Destroy(this.gameObject); //Destroy this object the create "Explosion" in same position
                for (int i = 0; i < 300; i++)
                    Instantiate(cube, pos, Quaternion.Euler(Mathf.Sin(Time.time), Mathf.Sin(Time.time), Mathf.Sin(Time.time)));
            }
        }
    }
}
