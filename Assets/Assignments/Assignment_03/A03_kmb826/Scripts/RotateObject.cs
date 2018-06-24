using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826_assignment3
{
    public class RotateObject : MonoBehaviour
    {

        public static RotateObject Singleton;
        private readonly float speed = 10f;

        private void Awake()
        {
            if (Singleton == null)
                Singleton = this;
            else if (Singleton != this)
                Destroy(this);
        }

        public void Activate()
        {
            PickUpObject.rotate = true;
        }

        public void Deactivate()
        {
            PickUpObject.rotate = false;
        }

        public void Rotate(Vector3 eulers)
        {
            transform.Rotate(eulers * speed);
        }
    }
}
