using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    public Vector3 center;
    public Vector3 size;
    public GameObject cubeSpawn;
    public GameObject sphereSpawn;
    private Material matOfObject;
    public int amount;

	// Use this for initialization
	void Start () {
        spawn(amount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,5f);
        Gizmos.DrawCube(center,size);

    }
    private void spawn(int number){
        for (int i = 0; i < number;i++){
            float cubeSize = Random.Range(0, size.x / 40);
            float sphereSize = Random.Range(0, size.x / 20);
            Vector3 pos1 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Vector3 pos2 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject rep1=Instantiate(cubeSpawn, pos1, Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));
            GameObject rep2 = Instantiate(sphereSpawn, pos2, Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));
            rep1.transform.localScale=new Vector3(cubeSize, cubeSize, cubeSize);
            rep1.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(Random.Range(0, 8),Random.Range(0, 8),Random.Range(0, 8),Random.Range(0, 8)));
            rep2.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
            rep2.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8)));

        }
       
    }

}
