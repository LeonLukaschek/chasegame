using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDead : MonoBehaviour {


	PlayerController pc;
	GameManager gm;
	ScoreboardManager sm;

	void Start () {
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		sm = gm.GetComponent<ScoreboardManager> ();
	}
	

	void Update () {
		
	}

	public void StopPlayer(){
		StopTrafficCars ();

		pc.Velocity = 0;
		pc.IsAlive = false;

		sm.ShowScoreboard ();
	}

	void StopTrafficCars(){
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("TrafficCar")) {
			g.GetComponent<TrafficCar> ().speed = 0;
		}

		GameManager gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		gm.StopAllCoroutines ();
	}
}
