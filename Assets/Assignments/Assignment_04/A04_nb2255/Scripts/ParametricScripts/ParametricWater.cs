

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class ParametricWater : MonoBehaviour
    {

        public int uDivs = 90;
        public int vDivs = 90;
        public float speed = 1;

        void Start()
        {
            GetComponent<MeshFilter>().mesh = Grid.Generate(uDivs, vDivs, Landscape);
        }

        Vector3 Landscape(float u, float v)
        {
            float distance = Vector2.Distance(new Vector2(u, v), new Vector2(.5f, .5f));

            //sample naise, while offsetting by time -- giving wave illusion
            //float noise1 = CT.Noise.GetNoise(new Vector3(3 * u + (Time.time * speed), 3 * v, 0.5f));
            //float noise2 = CT.Noise.GetNoise(new Vector3(12 * u + (Time.time * speed), 12 * v, 4.5f));

            float noise1 = Mathf.PerlinNoise(3 * u + (Time.time * speed), 3 * v);
            float noise2 = Mathf.PerlinNoise(12 * u + (Time.time * speed), 12 * v);

            return new Vector3(2 * u - 1,
                               (.5f * (noise1 + noise2 * .2f)),
                               2 * v - 1);
        }

        private void Update()
        {
            //just like parametric landscape, except re-renders every frame
            GetComponent<MeshFilter>().mesh = Grid.Generate(uDivs, vDivs, Landscape);
        }

    }
}