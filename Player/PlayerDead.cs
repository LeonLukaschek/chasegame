using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDead : MonoBehaviour {


	PlayerController pc;

	public GameObject scoreboardHolder;


	void Start () {
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		scoreboardHolder = GameObject.FindGameObjectWithTag ("Scoreboard").gameObject;

		scoreboardHolder.gameObject.SetActive (false);
	}
	

	void Update () {
		
	}

	public void StopPlayer(){
		pc.Velocity = 0;
		StopTrafficCars ();

		scoreboardHolder.gameObject.SetActive (true);
	}

	void StopTrafficCars(){
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("TrafficCar")) {
			g.GetComponent<TrafficCar> ().speed = 0;
		}

		GameManager gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		gm.StopAllCoroutines ();
	}
}
