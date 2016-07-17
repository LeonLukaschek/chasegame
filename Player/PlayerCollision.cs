using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private PlayerController player;
	private PlayerHealth pHealth;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		pHealth = player.transform.GetComponentInChildren<PlayerHealth> ();
		Debug.Log ("ALDKFJÖ");
	}
	

	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "TrafficCar") {
			Debug.Log("hit");
			pHealth.removePlayerHealth ();
		}
	}
}
