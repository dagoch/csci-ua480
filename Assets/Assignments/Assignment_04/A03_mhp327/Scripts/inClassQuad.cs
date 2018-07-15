using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inClassQuad : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Mesh mesh = new Mesh();
        Mesh mesh2 = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshFilter>().mesh = mesh2;

        Vector3[] vertices = new Vector3[7];
        Vector3[] normals = new Vector3[7];

        vertices[0] = new Vector3(-1, 1, 0);
        vertices[1] = new Vector3(1, 1, 0);
        vertices[2] = new Vector3(1, -1, 0);
        vertices[3] = new Vector3(-1, 1, 0);
        vertices[4] = new Vector3(0, 2, 1);
        vertices[5] = new Vector3(2, 2, 1);
        vertices[6] = new Vector3(2, 0, 1);
        vertices[7] = new Vector3(0, 2, 1);

        int[] triangles = new int[] { 0, 1, 3, 3, 1, 2,
                                        3,1,0,2,1,3};

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();


        for (int i = 0; i < normals.Length; i ++){
            if (i < 4){
                normals[i] = Vector3.one * -1;
            }
            else{
                mesh.normals = normals;
            }
        }



        Vector3[] vertices2 = new Vector3[4];
        Vector3[] normals2 = new Vector3[4];

        vertices2[0] = new Vector3(0, 2, 1);
        vertices2[1] = new Vector3(2, 2, 1);
        vertices2[2] = new Vector3(2, 0, 1);
        vertices2[3] = new Vector3(0, 2, 1);

        int[] triangles2 = new int[] { 1, 2, 4,4, 2, 3,
                                        4,2,1,3,2,4};

        mesh2.vertices = vertices2;
        mesh2.triangles = triangles2;
        mesh2.RecalculateNormals();


        for (int i = 0; i < normals.Length; i++)
        {
            if (i < 4)
            {
                normals2[i] = Vector3.one * -1;
            }
            else
            {
                mesh2.normals = normals2;
            }
        }

	}
	

}
