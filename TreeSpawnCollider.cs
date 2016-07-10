using UnityEngine;
using System.Collections;

public class TreeSpawnCollider : MonoBehaviour {


	private bool b_isColliding;

	void Start () {
	
	}
	

	void Update () {
	
	}

	public bool isColliding(){
		return b_isColliding;
	}

	void OnCollisionStay(Collision c){
		if (c.gameObject.tag == "Tree") {
			b_isColliding = true;
		}
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Tree") {
			b_isColliding = true;
		}
	}

	void OnCollisionExit(Collision c){
		if (c.gameObject.tag == "Tree") {
			b_isColliding = false;
		}
	}
}
