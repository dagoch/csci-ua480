using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script comes from the tuturoial for procedural grids by https://catlikecoding.com/unity/tutorials/procedural-grid/

namespace A04_ank352 {

	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class Grid : MonoBehaviour {

		public int xSize, ySize;
		private Mesh mesh;

		//Generate mesh when object awakens
		private void Awake () {
			Generate();
		}

		//Array to hold vertices
		private Vector3[] vertices;

		//Instantiate vertices
		private void Generate () {
				//Create mesh filter
				GetComponent<MeshFilter>().mesh = mesh = new Mesh();
				mesh.name = "Procedural Grid";

				vertices = new Vector3[(xSize + 1) * (ySize + 1)]; //Declare vertices array
				Vector2[] uv = new Vector2[vertices.Length]; //Array for textures
				Vector4[] tangents = new Vector4[vertices.Length];
				Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);

				//Instantiate vertices array
				for (int i = 0, y = 0; y <= ySize; y++) {
					for (int x = 0; x <= xSize; x++, i++) {
						vertices[i] = new Vector3(x, y);
						uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
						tangents[i] = tangent;
					}
				}
				mesh.vertices = vertices;
				mesh.uv = uv;
				mesh.tangents = tangents;

				//Declare and initialize triangles to fit grid
				int[] triangles = new int[xSize * ySize * 6];
				for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
					for (int x = 0; x < xSize; x++, ti += 6, vi++) {
						triangles[ti] = vi;
						triangles[ti + 3] = triangles[ti + 2] = vi + 1;
						triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
						triangles[ti + 5] = vi + xSize + 2;
					}
				}
				mesh.triangles = triangles;
				mesh.RecalculateNormals();
			}

		//Visualization of grid using gizmos
		// private void OnDrawGizmos () {
		// 	if (vertices == null) {
		// 		return;
		// 	}
		// 	Gizmos.color = Color.black;
		// 	for (int i = 0; i < vertices.Length; i++) {
		// 		Gizmos.DrawSphere(vertices[i], 0.1f);
		// 	}
		// }
	}
}
