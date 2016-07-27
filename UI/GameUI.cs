using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour {

	public GameObject holder;

	public Text distanceNumber_txt;
	public Text speedNumber_txt;
	public Text hpNumber_txt;

	private PlayerController pc;
	private PlayerHealth ph;

	int counter = 0;

	void Start () {
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();

	}
	

	void Update () {
		while (ph == null) {
			ph = GameObject.FindGameObjectWithTag ("PlayerCar").GetComponent<PlayerHealth> ();
		}
	}

	public void ShowGameUI(bool b){
		if (b) {
			holder.SetActive (true);
			
			SetTexts ();

		} else {
			holder.SetActive (false);
		}
	}

	void SetTexts(){
		distanceNumber_txt.text = Mathf.RoundToInt (pc.Distance).ToString () + " m";
		speedNumber_txt.text = Mathf.RoundToInt (pc.Velocity * 4).ToString () + " km/h";
		hpNumber_txt.text = ph.Health.ToString () + " HP";
	}
}
