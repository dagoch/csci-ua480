using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple script that I want to use to make sure the dog is always looking toward the vehicle

namespace kmb826_assignment02
{
    public class LookAt : MonoBehaviour
    {

        public Transform player;

        void Update()
        {
            transform.LookAt(player.position);
        }
    }
}
