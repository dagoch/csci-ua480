using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01Examples
{
    public class snakeTrail : MonoBehaviour
    {

        List<Vector3> PreviousPositions;
        List<GameObject> balls;

        public int amount;
        public GameObject ball;


        // Use this for initialization
        void start()
        {

            PreviousPositions = new List<Vector3>();
            balls = new List<GameObject>();

            for (int i = 0; i < amount; i++)
            {
                balls.Add(Instantiate(ball));
                //balls.Add(b);
                PreviousPositions.Add(Vector3.zero);
            }

        }

        void update()
        {

            PreviousPositions.Add(this.transform.position);

            if (PreviousPositions.Count > amount)
            {
                PreviousPositions.RemoveAt(0);
            }
            for (int i = 0; i < amount; i++)
            {
                balls[i].transform.position = PreviousPositions[i];
            }
        }
    }
}