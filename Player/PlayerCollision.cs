using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private PlayerController player;
	private PlayerHealth pHealth;
	private GameObject car;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		pHealth = player.transform.GetComponentInChildren<PlayerHealth> ();
		car = GameObject.FindGameObjectWithTag ("PlayerCar");
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "TrafficCar") {
			StartCoroutine (PlayerTookDamage ());
		}
	}

	IEnumerator PlayerTookDamage(){
		pHealth.removePlayerHealth ();

		if (!(pHealth.Health <= 0)) {			
			float beforeSpeed = player.Velocity;
			player.Velocity = beforeSpeed / 2;
			
			Physics.IgnoreLayerCollision (9, 9, true);
			car.GetComponent<Rigidbody> ().isKinematic = true;
			
			
			//car.GetComponentInChildren<BoxCollider> ().isTrigger = true;
			//gm.StopCoroutine (gm.spawnTraffic ());
			
			triggerActive(false);
			
			yield return new WaitForSeconds (0.5f);
			
			//car.transform.position = new Vector3 (-0.725f, transform.position.y, transform.position.z);
			
			triggerActive(true);
			
			yield return new WaitForSeconds (0.45f);
			
			triggerActive(false);
			
			yield return new WaitForSeconds (0.45f);
			
			triggerActive(true);
			
			yield return new WaitForSeconds (0.45f);
			
			triggerActive(false);
			
			yield return new WaitForSeconds (0.25f);
			
			triggerActive(true);
			
			//car.GetComponentInChildren<BoxCollider> ().isTrigger = false;
			//gm.StartCoroutine (gm.spawnTraffic ());
			car.GetComponent<Rigidbody> ().isKinematic = false;
			player.Velocity = beforeSpeed;
			
			yield return new WaitForSeconds (1.5f);
			
			Physics.IgnoreLayerCollision (9, 9, false);
			
			yield return null;
		}
	}

	void triggerActive(bool trigger){
		for (int i = 0; i < car.transform.childCount; i++) {
			GameObject g = car.transform.GetChild (i).gameObject;
			g.gameObject.SetActive (trigger);
		}
	}
}
