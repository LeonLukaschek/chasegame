using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	private GameManager gManager;

	void Awake(){
		gManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		gManager.currentSpawnedTrees++;
	}

	void OnDestroy(){
		gManager.currentSpawnedTrees--;
	}
}
