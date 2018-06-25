using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ar4477.A03 {
    [RequireComponent(typeof(Slider))]
    public class Translate : MonoBehaviour
    {
        public float prev;

        // Because slider values are not negative, and the forces are 
        // forward and backward, compare the current value of the slider 
        // with the new value of the slider to determine which direction to go in.
        public void Move(float current)
        {
            if (prev < current)
            {
                transform.Translate(Vector3.forward * current * 0.5f);
            }
            if (prev > current)
            {
                transform.Translate(Vector3.back * current * 0.5f);
            }
            // update previous value to current for future comparisons
            prev = current;
        }
    }
}
