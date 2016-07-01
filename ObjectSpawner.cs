using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * 
 * Used to spawn different objects like buildings or trees
 * 
 */ 

public class ObjectSpawner : MonoBehaviour {
	[Header("Prefabs")]
	public List<GameObject> grassPrefs = new List<GameObject>();
	public List<GameObject> treePrefs = new List<GameObject>();
	public List<GameObject> roadPrefabs = new List<GameObject>();
	public GameObject grassPrefab;
	[Space(10)]
	[Header("Other")]
	public GameManager gManager;
	public Transform holder;

	/*
	 * Multiple times the same method, but with different arguments
	 */ 

	//Spawing an amount of random items from a list of prefabs at a positions and rotation
	public void SpawnObject(List<GameObject> prefabs, int count, Vector3 position, Quaternion rotation ){
		for (int i = 0; i < count; i++) {
			//Using float becasue Random.Range with ints excludes the number entered -> if prefabs.Count = 10 max will be 9
			float rnd = Random.Range (0, prefabs.Count);
			GameObject spawnedObject = Instantiate (prefabs[(int)rnd].gameObject, position, rotation) as GameObject;
			//Setting the parent of the new gameobject to holder -> scene is more "clean"
			spawnedObject.transform.SetParent (holder);
		}
	}

	public void SpawnObject(List<GameObject> prefabs, int count, Vector3 position, Vector3 rotation ){
		for (int i = 0; i < count; i++) {
			int rnd = Random.Range (0, prefabs.Count);
			GameObject spawnedObject = Instantiate (prefabs[(int)rnd].gameObject, position, Quaternion.Euler(rotation)) as GameObject;

			spawnedObject.transform.SetParent (holder);
		}
	}

	public void SpawnObject(List<GameObject> prefabs, int count, Vector3 position){
		for (int i = 0; i < count; i++) {
			int rnd = Random.Range (0, prefabs.Count);
			GameObject spawnedObject = Instantiate (prefabs[(int)rnd].gameObject, position, prefabs[rnd].transform.rotation) as GameObject;
			spawnedObject.transform.SetParent (holder);
		}
	}

	public GameObject SpawnObject(List<GameObject> prefabs, Vector3 position){
			int rnd = Random.Range (0, prefabs.Count);
			GameObject spawnedObject = Instantiate (prefabs[(int)rnd].gameObject, position, prefabs[rnd].transform.rotation) as GameObject;
			spawnedObject.transform.SetParent (holder);

		return spawnedObject;
	}

	public GameObject SpawnObject(GameObject prefabs, Vector3 position){
		GameObject spawnedObject = Instantiate (prefabs.gameObject, position, prefabs.transform.rotation) as GameObject;
		spawnedObject.transform.SetParent (holder);
		return spawnedObject;
	}

	public void SpawnObject(GameObject prefab, int count, Vector3 position, Quaternion rotation){
		for (int i = 0; i < count; i++) {
			
			GameObject spawnedObject = Instantiate (prefab.gameObject, position, rotation) as GameObject;
			spawnedObject.transform.SetParent (holder);
		}
	}

	public void SpawnObject(GameObject prefab, int count, Vector3 position){
		for (int i = 0; i < count; i++) {

			GameObject spawnedObject = Instantiate (prefab.gameObject, position, Quaternion.identity) as GameObject;
			spawnedObject.transform.SetParent (holder);
		}
	}

	//Spawing the road 
	public void SpawnRoad(){
		Vector3 spawnPos = new Vector3 (1, 0, gManager.GetCurrentZ ());

		Vector3 rot = new Vector3(0, 90, 0);

		SpawnObject (roadPrefabs, 1, spawnPos, Quaternion.Euler(rot));

	}

	//Spawning an amount of trees
	public void SpawnTree(int count = 1){
		for (int i = 0; i < count; i++) {
			//Getting a random xPos
			float rnd = Random.Range (0, 10f);

			float xPosMin;
			float xPos;

			if (rnd >= 5) {
				xPosMin = 1f;
				xPos = Random.Range (xPosMin, 7.1f);
			} else {
				xPosMin = -2.7f;
				xPos = Random.Range (xPosMin, -8.9f);
			}
			//Random rotation
			Vector3 rot = new Vector3(0, Random.Range(0, 360), 0);
			//Spawn position: x =  xPos calculated above, y = 0.5 + Random between -0.2 - 0.2, z = currentZ + Random between -5, 5 
			Vector3 spawnPos = new Vector3 (xPos, 0.5f + Random.Range (-0.2f, 0.2f), gManager.GetCurrentZ () + Random.Range (-5, 5));
			SpawnObject (treePrefs, 1, spawnPos, Quaternion.Euler(rot));
		}
	}
	//Same as spawn tree but with different x values
	public void SpawnGrass(int count = 1){
		for (int i = 0; i < count; i++) {	

			float rnd = Random.Range (0, 10f);
			float xPosMin;
			float xPos;

			if (rnd >= 5) {
				xPosMin = 0.81f;
				xPos = Random.Range (xPosMin, 7.1f);
			} else {
				xPosMin = -2.7f;
				xPos = Random.Range (xPosMin, -9.1f);
			}

			Vector3 rot = new Vector3(0, Random.Range(0, 360), 0);

			Vector3 spawnPos = new Vector3 (xPos, 0.62f, gManager.GetCurrentZ ());
			SpawnObject (grassPrefs, 1, spawnPos, Quaternion.Euler(rot));
		}
	}

	public void SpawnGrassBlock(){
		Vector3 position = new Vector3 (15f, 0f, gManager.GetCurrentZ () + 133f);
		SpawnObject (grassPrefab, position);
	}
}
