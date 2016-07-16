using UnityEngine;
using System.Collections;

public class CarPickingCarMover : MonoBehaviour {
	public float speed = 2;


	void Update () {
		transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed, Space.World);

	}
}
