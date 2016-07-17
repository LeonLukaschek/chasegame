using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	private int health;

	private PlayerDead pDead;

	void Start () {
		pDead = GameObject.FindGameObjectWithTag ("PlayerCar").GetComponent<PlayerDead> ();

		health = PlayerPrefs.GetInt("Health");

		//Only used in debug because unity does not use playerprefs when debugging
		if (health == 0) {
			health = 4;
		}
	}
	

	void Update () {
		healthManager ();
	}

	public void removePlayerHealth(int decrease = 1){
		health -= decrease;
	}

	private void healthManager(){
		if (health <= 0) {
			pDead.StopPlayer ();
		}
	}
}