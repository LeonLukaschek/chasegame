using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private int health;

	void Start () {
		health = PlayerPrefs.GetInt("Health");
		Debug.Log("Player-Health: " + health + " " + "PlayerPrefs-Health: " + PlayerPrefs.GetInt("Health"));
	}
	

	void Update () {
		
	}

	public void removePlayerHealth(int decrease = 1){
		health -= decrease;
	}

	public void healthManager(){
		if (health <= 0) {
			Debug.Log ("Dead");
		}
	}
}
