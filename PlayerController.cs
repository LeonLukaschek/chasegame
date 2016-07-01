using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * 
 * Input form user
 * 
 */

public class PlayerController : MonoBehaviour {
	[Header("Player Settings")]
	public GameObject car;
	[Range(0, 20)]
	public float velocity;

	void Update () {
		//Keyboard input
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			float inputZ = Input.GetAxis ("Horizontal");	//Left & right input
			this.transform.Translate (new Vector3 (inputZ  * Time.deltaTime * (velocity * 0.75f), 0, velocity * Time.deltaTime)); // Moving the player
		}


		//Mobile input
		//If there is a touch and the touch does not move, move the car in the direction of the touch (Left/Right)
		if (SystemInfo.deviceType == DeviceType.Handheld) {
			car.transform.Translate (0, 0, Input.acceleration.x * 0.75f);
			this.transform.Translate (new Vector3 (0, 0, velocity * Time.deltaTime)); // Moving the player


			if (Input.touchCount > 0) {
				
				Touch touch;
				touch = Input.GetTouch (0);
				if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Began) {
					if (touch.position.x < Screen.width / 2) {
						car.transform.position -= new Vector3 (0.1f, 0, 0);
					} else if (touch.position.y > Screen.width / 2) {
						car.transform.position += new Vector3 (0.1f, 0, 0);
					}
				}
			}
		}

		//limit the palyers x position to -1.25 to -0.1 so that it wont leave the street
		if (car.transform.position.x < -1.525f) {
			car.transform.position = new Vector3 (-1.525f, car.transform.position.y, car.transform.position.z);
		}

		if (car.transform.position.x > -0.1f) {
			car.transform.position = new Vector3 (-0.1f, car.transform.position.y, car.transform.position.z);
		}
	}
}