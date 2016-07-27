using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour {

	public GameObject holder;

	public Text distanceNumber_txt;

	private PlayerController pc;

	void Start () {
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
	}
	

	void Update () {
		
	}

	public void ShowGameUI(bool b){
		if (b) {
			holder.SetActive (true);
			
			distanceNumber_txt.text = Mathf.RoundToInt (pc.Distance).ToString ();

		} else {
			holder.SetActive (false);
		}
	}
}
