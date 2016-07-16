using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarPickingLevel : MonoBehaviour {

	public CarPickingObjectSpawner cpos;
	[Range(0.5f, 5f)]
	public float timeBtwSpawnsMin, timeBtwSpawnsMax;
	public float treeCount;

	public GameObject colliderTester;

	public List<GameObject> cars = new List<GameObject> ();
	public List<GameObject> treePrefs = new List<GameObject> ();

	void Awake() {
		StartCoroutine (carSpawing ());
		StartCoroutine (SpawnTree ());
	}

	//Spawning the cars in the background
	IEnumerator carSpawing(){
		while (true) {
			Vector3 spawnPos = new Vector3 (-15f , 2.65f, Random.Range(7.35f,8.50f));
			Vector3 spawnRot = new Vector3 (270f, 90f, 0f);
			
			GameObject spawned = cpos.SpawnObject (cars, spawnPos, spawnRot) as GameObject;

			Destroy (spawned.GetComponent<BehindCamEnv> ());

			yield return new WaitForSeconds (Random.Range(timeBtwSpawnsMin, timeBtwSpawnsMax));
		}

		yield return null;
	}
		
	public IEnumerator SpawnTree(int count = 1){
		//Destroying all trees before spawning new ones, used for debugging
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Tree")) {
			Destroy (g);
		}

		for (int i = 0; i < treeCount; i++) {
			//Getting a random xPos
			float rnd = Random.Range (0, 10f);
			bool shoudSpawn = false;

			float zPosMin;
			float zPos;

//			if (rnd >= 5) {
//				zPosMin = 2f;
//				zPos = Random.Range (zPosMin, 6f);
//			} else {
				zPosMin = 10f;
				zPos = Random.Range (zPosMin, 45f);
//			}

			//Random rotation
			Vector3 rot = new Vector3(0, Random.Range(0, 360), 0);

			Vector3 spawnPos = new Vector3 (Random.Range(-25f, 90f), -3.8f, zPos);

			colliderTester.transform.position = spawnPos;

			if (colliderTester.GetComponent<TreeSpawnCollider> ().isColliding()) {
				shoudSpawn = false;
			} else if(!colliderTester.GetComponent<TreeSpawnCollider> ().isColliding()){
				shoudSpawn = true;
			}

			if (shoudSpawn) {
				GameObject spawnedTree = cpos.SpawnObject (treePrefs, spawnPos, rot) as GameObject;
				Destroy (spawnedTree.GetComponent<BehindCamEnv> ());
			} else {
				i--;
			}
		}

		yield return null;
	}
}
