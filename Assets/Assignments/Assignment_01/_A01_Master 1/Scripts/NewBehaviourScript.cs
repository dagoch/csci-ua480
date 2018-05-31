using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A01zs967
{
    public class NewBehaviourScript : MonoBehaviour
    {

        public Rigidbody rb;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            rb.AddForce(0, 0, 2000 * Time.deltaTime);
        }
    }
}