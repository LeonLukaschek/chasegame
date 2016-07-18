using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private PlayerController player;
	private PlayerHealth pHealth;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		pHealth = player.transform.GetComponentInChildren<PlayerHealth> ();
	}
	

	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "TrafficCar") {
			pHealth.removePlayerHealth ();
		}
	}
}
