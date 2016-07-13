using UnityEngine;
using System.Collections;

public class CarPickingCarMover : MonoBehaviour {
	public float speed = 2;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed, Space.World);

	}
}
