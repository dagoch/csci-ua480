using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wmc286
{
    public class WestWallController : MonoBehaviour
    {
        public GameObject player;
        private bool wallRaised;
        private bool isOnWestSide;
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
            float wallXPos = transform.position.x;
            float playerXPos = player.transform.position.x;

            isOnWestSide = (int)playerXPos < 0;

            wallXPos = wallXPos < 0 ? -wallXPos : wallXPos;
            playerXPos = playerXPos < 0 ? -playerXPos : playerXPos;
            int xPosDiff = (int)(wallXPos - playerXPos);

            if (xPosDiff == 0 && !wallRaised && isOnWestSide)
            {
                transform.position = new Vector3(x, 0.5f, z);
                wallRaised = true;
            }
            else if (xPosDiff > 1 && wallRaised && !isOnWestSide)
            {
                transform.position = new Vector3(x, -0.5f, z);
                wallRaised = false;
            }
        }
    }
}