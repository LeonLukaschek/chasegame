using UnityEngine;
using System.Collections;

public class TrafficCar : MonoBehaviour {

	public float speed = 2;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed * (-1), Space.World);

	}
}
