using UnityEngine;
using System.Collections;

/*
 * 
 * Used to see if the collison component collides with something:
 * 																 if not : there is no street -> should spawn objects 
 * 												  collides with someting: there is already a street -> dont spawn 
 */ 
public class RoadCollisonChecker : MonoBehaviour {

	public GameObject colliderHelper;

	public int counter, counter_grass;

	void Awake () {
		counter = 0;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Street") {
			counter++;
		}

		if (other.gameObject.tag == "Grass") {
			counter_grass++;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Street") {
			counter--;
		}

		if (other.gameObject.tag == "Grass") {
			counter_grass--;
		}
	}

	public bool shouldSpawnGrass(){
		return counter_grass <= 0 ? true : false;
	}

	public bool shouldSpawnObjects(){
		return counter <= 0 ? true : false;
	}
}