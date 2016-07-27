using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	private int health;

	private ManagerUI mUI;

	private PlayerDead pDead;
	private bool shoudCheckHP;

	void Start () {
		pDead = GameObject.FindGameObjectWithTag ("PlayerCar").GetComponent<PlayerDead> ();
		mUI = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<ManagerUI> ();
		health = PlayerPrefs.GetInt("Health");

		shoudCheckHP = true;

		//Only used in debug because unity does not use playerprefs when debugging
		if (health == 0) {
			health = 4;
		}
	}
	

	void Update () {
		if (shoudCheckHP) {
			healthManager ();
		}

	}

	public void removePlayerHealth(int decrease = 1){
		health -= decrease;
	}

	private void healthManager(){
		if (health <= 0) {
			pDead.StopPlayer ();
			shoudCheckHP = false;
			mUI.GameOver = true;

		}
	}

	public int Health {
		get {
			return this.health;
		}
		set {
			health = value;
		}
	}
}