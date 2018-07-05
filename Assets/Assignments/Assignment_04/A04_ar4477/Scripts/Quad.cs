using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A04 
{
    // this script is attached the bush
    public class Quad : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Mesh mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;

            // create 300 vertices and 900 triangles
            Vector3[] vertices = new Vector3[300];
            int[] triangles = new int[900];

            // randomly place a vertex inside a sphere unit and add it 
            // the array of vertices
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = Random.insideUnitSphere;

            // randomly assign a number to each element in the triangles array
            for (int j = 0; j < triangles.Length; j++)
                triangles[j] = (int)(Random.value * 299 + 1);

            // attach the trianges and vertices to the mesh, and recalculate normals
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();
        }

    }

}
