using UnityEngine;
using System.Collections;

public class PlayerDistance : MonoBehaviour {


	private PlayerController player;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
	}
	

	void Update () {
	
	}


}
