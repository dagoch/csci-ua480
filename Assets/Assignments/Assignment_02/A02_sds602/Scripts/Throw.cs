using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sds602.A02
{
    public class Throw : MonoBehaviour
    {
        public GameObject prefab;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            { //upon mouse click, instantiates new sphere object
                GameObject ball = Instantiate(prefab) as GameObject;
                prefab.transform.position = transform.position + Camera.main.transform.forward;
                Rigidbody rb = prefab.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * 40; //causes sphere to move forward
            }
        }
    }
}