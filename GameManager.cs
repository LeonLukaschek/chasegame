using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * 
 * Controlling the spawning of objects
 *
 */

public class GameManager : MonoBehaviour {
	//Different spawnareas of the game
	[Header("Spawn settings")]
	public currentArea cArea;
	public float timeBetweenAreaChanges = 5f;

	public float timeBetweenCarSpawnsMax = 10f;
	public float timeBetweenCarSpawnsMin = 3f;
	public int highwayGrassBlocks, forestGrassBlocks, connectorGrassBlocks;
	public List<GameObject> roadPrefabs = new List<GameObject>();
	[Space(10)]
	[Header("References to other objects")]
	public RoadCollisonChecker rcc;
	public TrafficSpawner tSpawner;
	public ObjectSpawner oSpawner;
	public Transform holder;

	public enum currentArea
	{
		CITY,
		FOREST,
		HIGHWAY,
		CONNECTOR
	}


	private int spawnedStreetsCounter = 1;
	private int treeSpawns = 1, grassSpawns = 1;
	private float timeBetweenCarSpawns = 5f;

	// Use this for initialization
	void Start () {
		cArea = currentArea.CONNECTOR;
		StartCoroutine (rollNewArea ());
		StartCoroutine (spawnTraffic());

	}
	
	// Update is called once per frame
	void Update () {
		if (rcc.shouldSpawnObjects()) {
			SpawnManager ();
		}
	}

	void SpawnManager(){
		//Different amount of trees and grass at different areas
		switch (cArea) {
		case currentArea.CONNECTOR:
			treeSpawns = 1;
			grassSpawns = 2;


			//Spawnin the right amount of grassblocks
			oSpawner.SpawnGrassBlock (connectorGrassBlocks);
			break;
		case currentArea.FOREST:
			treeSpawns = 5;
			grassSpawns = 3;


			oSpawner.SpawnGrassBlock (forestGrassBlocks);
			break;
		case currentArea.HIGHWAY:
			treeSpawns = 0;
			grassSpawns = 5;


			oSpawner.SpawnGrassBlock (highwayGrassBlocks);
			break;
		case currentArea.CITY:
			treeSpawns = 0;
			grassSpawns = 0;


			oSpawner.SpawnGrassBlock (highwayGrassBlocks);
			break;
		default:
			treeSpawns = 0;
			grassSpawns = 0;
			Debug.Log ("Default area used");
			break;
		}

		//Calling the spawn methods form Objectspawner
		oSpawner.SpawnRoad ();
		oSpawner.SpawnTree (treeSpawns);
		oSpawner.SpawnGrass (grassSpawns);
		timeBetweenCarSpawns = Random.Range (timeBetweenCarSpawnsMin, timeBetweenCarSpawnsMax);

		spawnedStreetsCounter++;
	}
	//Gets the current z where the next road/tree/etc. has to be spawned
	public float GetCurrentZ(){
		return 28.3f + (3.1f * spawnedStreetsCounter);
	}
	//Getting a new area evry x seconds
	IEnumerator rollNewArea(){
		while (true) {
			yield return new WaitForSeconds (timeBetweenAreaChanges);
			cArea = (currentArea)Random.Range (0, 3);
			Debug.Log ("Changed area to: " + cArea.ToString ());
		}
	}

	IEnumerator spawnTraffic(){
		while(true){
			yield return new WaitForSeconds (timeBetweenCarSpawns);
			tSpawner.SpawnTrafficCar ();

			Debug.Log ("Spawned car");
		}
	}
}