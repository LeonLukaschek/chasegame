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
		oSpawner.SpawnObject (carPrefabs, 1, new Vector3 (Random.Range(-1.38f,-0.22f), 1.5f, gManager.GetCurrentZ () -3));
	}
}
