using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CarLoader : MonoBehaviour {

	public CarPicker cPicker;

	private GameObject g;
	private List<GameObject> cars = new List<GameObject> ();

	void Start () {
		cars = cPicker.carsToPick;
	}
	

	void Update () {
		
	}

	public void OnStartPress(){
		SavePlayerPrefs ();

		SceneManager.LoadScene ("test");
	}

	//Saves all PlayerPrefs needed for the game
	private void SavePlayerPrefs(){
		PlayerPrefs.SetInt ("Selected_Car", cPicker.GetCurrentCarIndex());
		foreach (var car in cars) {
			car.transform.parent.GetComponent<CarStats> ().SaveStats ();
		}
	}
}
