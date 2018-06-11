using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_cc5341
{

    public class reset_tray : MonoBehaviour
    {
        Vector3 initial;


        void Start()
        {
            initial = GameObject.Find("tray").transform.eulerAngles;


        }


        void Update()
        {

            RaycastHit hit;
            if (Input.GetKey(KeyCode.R) && Physics.Raycast(transform.position, transform.forward, out hit)){
                GameObject.Find("tray").transform.eulerAngles = initial;

            }
                
        }
    }
}