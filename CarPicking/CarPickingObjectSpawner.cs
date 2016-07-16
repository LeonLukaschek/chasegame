using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarPickingObjectSpawner : MonoBehaviour {

	public Transform holder;

	//Same one as the functions in ObjectSpawner but used only in the Car-Picking Scene
	public GameObject SpawnObject(List<GameObject> prefabs, Vector3 position, Vector3 rotation){
		int rnd = Random.Range (0, prefabs.Count);
		GameObject spawnedObject = Instantiate (prefabs[(int)rnd].gameObject, position, Quaternion.Euler(rotation)) as GameObject;
		spawnedObject.transform.SetParent (holder);

		return spawnedObject;
	}

	void Update () {
	
	}
}
