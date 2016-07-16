using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrafficSpawner : MonoBehaviour {

	public List<GameObject> carPrefabs;

	public ObjectSpawner oSpawner;
	public GameManager gManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SpawnTrafficCar(){
		GameObject spawnedCar = oSpawner.SpawnObject (carPrefabs, new Vector3 (Random.Range(-1.5f,-0.15f), 1.5f, gManager.GetCurrentZ () -3));
		//Setting the car speed to the one used in GameManager
		spawnedCar.GetComponent<TrafficCar> ().speed = gManager.carSpeed;
	}
}
