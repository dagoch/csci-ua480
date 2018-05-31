using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826
{
    public class FloorColor : MonoBehaviour
    {

        public GameObject gObj;

        void Start()
        {
            gObj.GetComponent<Renderer>().material.color = Color.green;
        }

    }
}
