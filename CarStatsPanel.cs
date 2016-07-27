using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CarStatsPanel : MonoBehaviour {

	public List<GameObject> cars = new List<GameObject>();

	public CarPicker cPicker;

	public Text carStatsText;

	//Updating the text to display the correct car informations
	public void UpdateCarInfo(){
		CarStats cs = cars[cPicker.GetCurrentCarIndex()].gameObject.GetComponent<CarStats> ();

		carStatsText.text = cs.Name.ToString () + "\nSpeed: " + (cs.Speed * 4).ToString() + " km/h" + "\nLives: " + cs.Health.ToString();
	}

}
