using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A04 
{
    // this script is attached to the plane
    public class MakeLandscape : MonoBehaviour
    {

        public GameObject house;    // select house 3D object in inspector
        GameObject newHouse;
        public GameObject quad;     // select bush 3D object in inspector
        GameObject newQuad;
        float perlinNoise;

        // Use this for initialization
        void Start()
        {
            // create 25 houses
            for (int i = 0; i < 25; i++)
            {
                // instantiate new house
                newHouse = Instantiate(house);
                // give new house random position
                newHouse.transform.position = new Vector3(Random.Range(-85f, 85f), transform.position.y + 5f, Random.Range(-85f, 85f));
                // create perlin noise using house's x and y positions
                perlinNoise = Mathf.PerlinNoise(newHouse.transform.position.x, newHouse.transform.position.y);
                // scale house according to perlin noise
                newHouse.transform.localScale = new Vector3(perlinNoise * .6f, perlinNoise * .6f, perlinNoise * .8f);
            }

            // create 50 bushes
            for (int i = 0; i < 50; i++)
            {
                // instantiate new bush
                newQuad = Instantiate(quad);
                // give new bush random position
                newQuad.transform.position = new Vector3(Random.Range(-90f, 90f), transform.position.y + 3f, Random.Range(-90f, 90f));
                // create perlin noise using bush's x and y positions
                perlinNoise = Mathf.PerlinNoise(newQuad.transform.position.x, newQuad.transform.position.y);
                // scale bush according to perlin noise
                newQuad.transform.localScale = new Vector3(perlinNoise * .6f, perlinNoise * .6f, perlinNoise * .8f);
            }
        }
    }
}
