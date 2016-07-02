using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CarPicker : MonoBehaviour {

	public List<GameObject> carsToPick = new List<GameObject>();

	public GameObject currentCarSelected;
	public Button leftButton;
	public Button rightButton;

	private int currentCar = 0;

	// Use this for initialization
	void Start () {
		currentCarSelected = carsToPick [currentCar].gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCar - 1 == -1) {
			leftButton.gameObject.SetActive (false);
		} else if (currentCar - 1 != -1) {
			leftButton.gameObject.SetActive (true);
		}

		if (currentCar + 1 == carsToPick.Count) {
			rightButton.gameObject.SetActive (false);
		} else if (currentCar + 1 != carsToPick.Count) {
			rightButton.gameObject.SetActive (true);
		}

		for (int i = 0; i < carsToPick.Count; i++) {
			carsToPick[i].gameObject.transform.Rotate(Vector3.up * 20f * Time.deltaTime, Space.World);
		}
	}

	public void onRightButtonClick(){
		if (currentCar + 1 != carsToPick.Count) {
			currentCar++;
			currentCarSelected = carsToPick [currentCar].gameObject;
		} else {
			
		}
	}

	public void onLeftButtonClick(){
		if (currentCar - 1 != -1) {
			currentCar--;
			currentCarSelected = carsToPick [currentCar].gameObject;
		} else {

		}
	}
}
