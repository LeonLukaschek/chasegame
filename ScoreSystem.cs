using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour {



	void Start () {
	
	}
	

	void Update () {
	
	}

	public void UpdateCoins(int n){
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score", 0) + n);
	}
}
