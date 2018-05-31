using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826
{
    public class FloorColor : MonoBehaviour
    {

        public GameObject gObj;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            gObj.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
