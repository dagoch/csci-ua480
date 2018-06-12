﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_zs967
{
    public class Shakes : MonoBehaviour
    {

        public float speed;
        public float amount;

        // Update is called once per frame
        void Update()
        {
            transform.localEulerAngles = new Vector3(0, Mathf.Sin(Time.time * speed) * amount, 0);
        }
    }
}