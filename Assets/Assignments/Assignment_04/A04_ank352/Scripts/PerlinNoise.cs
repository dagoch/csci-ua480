using UnityEngine;

namespace A04ank352
{
	public class PerlinNoise : MonoBehaviour {

		//Tutorial and script from https://www.youtube.com/watch?reload=9&v=vFvwyu_ZKfU

		public int depth = 5;

		public int width = 125;
		public int height = 125;

		public float scale = 10f;

		public float offsetX = 2f;
		public float offsetY = 2f;

	//Randomizes heights
	void Start() {
		// offsetX = Random.Range(0f, 100f);
		// offsetY = Random.Range(0f, 100f);
	}

		void Update() {
			Terrain terrain = GetComponent<Terrain>();
			terrain.terrainData = GenerateTerrain(terrain.terrainData);
		}

		TerrainData GenerateTerrain(TerrainData terrainData) {
			terrainData.heightmapResolution = width + 1;
			terrainData.size = new Vector3(width, depth, height);
			terrainData.SetHeights(0, 0, GenerateHeights());
			return terrainData;
		}

		float[,] GenerateHeights(){
			float[,] heights = new float[width, height];
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					heights[x,y] = CalculateHeight(x, y);// SOME PERLINE NOISE VALUE
				}
			}
			return heights;
		}

		float CalculateHeight(int x, int y) {
			float xCoord = (float) x / width * scale * offsetX;
			float yCoord = (float) y / height * scale * offsetY;

			return Mathf.PerlinNoise(xCoord, yCoord);
		}


	}
}
