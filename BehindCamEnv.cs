using UnityEngine;
using System.Collections;

/*
 *
 * Script is used to destroy all Enviromental gameobject (lilke trees, grass, buildings etc.) after the player passed them.
 * 
 */

public class BehindCamEnv : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible(){
		Destroy (gameObject, 0.5f);
	}
}
