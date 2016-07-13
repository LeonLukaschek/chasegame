using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	private GameManager gManager;

	void Awake(){
		if (gManager != null) {
			
			gManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
			gManager.currentSpawnedTrees++;
		}
	}

	void OnDestroy(){
		if (gManager != null) {
			gManager.currentSpawnedTrees--;
		}
	}
}
