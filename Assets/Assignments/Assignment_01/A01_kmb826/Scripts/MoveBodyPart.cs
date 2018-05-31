using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826 {
    public class MoveBodyPart : MonoBehaviour {

        public float speed = 5f;
        public float tiltAngle = 45.0f;

        void Update() {
            
            transform.rotation = Quaternion.Euler(0f, 0f, tiltAngle * Mathf.Sin(Time.time * speed));
     
        }
    }
}

