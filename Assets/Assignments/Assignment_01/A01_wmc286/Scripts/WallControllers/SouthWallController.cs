﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wmc286
{
    public class SouthWallController : MonoBehaviour
    {
        public GameObject player;
        private bool wallRaised;
        private bool isOnSouthSide;
        private float x;
        private float y;
        private float z;

        void Start()
        {
            wallRaised = false;
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
        }

        void LateUpdate()
        {
            float wallZPos = transform.position.z;
            float playerZPos = player.transform.position.z;

            isOnSouthSide = (int)playerZPos < 0;

            wallZPos = wallZPos < 0 ? -wallZPos : wallZPos;
            playerZPos = playerZPos < 0 ? -playerZPos : playerZPos;
            int xPosDiff = (int)(wallZPos - playerZPos);

            if (xPosDiff == 0 && !wallRaised && isOnSouthSide)
            {
                transform.position = new Vector3(x, 0.5f, z);
                wallRaised = true;
            }
            else if (xPosDiff > 1 && wallRaised && !isOnSouthSide)
            {
                transform.position = new Vector3(x, -0.5f, z);
                wallRaised = false;
            }
        }
    }
}