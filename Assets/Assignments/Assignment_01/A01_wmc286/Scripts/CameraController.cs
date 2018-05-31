using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wmc286
{
    public class CameraController : MonoBehaviour
    {
        // offset below found on Unity Roll a Ball tutorial
        public GameObject player;
        private Vector3 offset;

        void Start()
        {
            offset = transform.position - player.transform.position;
        }

        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}