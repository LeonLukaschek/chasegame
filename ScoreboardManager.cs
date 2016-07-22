using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreboardManager : MonoBehaviour {

	public GameObject scoreboardHolder;
	public ScoreSystem ss;
	[Space(5f)]
	[Header("Text-Object references")]
	public Text youDroveText;
	public Text distanceText;
	public Text coinsEarnedText;
	public Text socialNetworkText;
	public Text newHighscoreText;
	public Text bonusCoinsText;
	public Text currentCoinsText;
	public Text currentCoinsNumberText;
	public Text upgradesText;

	private PlayerController player;

	void Start () {
		scoreboardHolder.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	

	void Update () {
	
	}

	public void ShowScoreboard(){
		scoreboardHolder.SetActive (true);

		SetTexts ();

		ss.UpdateCoins (Mathf.RoundToInt (player.Distance) / 10);
	}

	void SetTexts(){
		youDroveText.text 			= "YOU DROVE";
		distanceText.text 			= Mathf.RoundToInt(player.Distance) + " m";
		coinsEarnedText.text 		= "AND EARNED " + (Mathf.RoundToInt(player.Distance) / 10)  + " COINS";
		socialNetworkText.text 		= "CHALLENGE YOUR FRIENDS ON";
		newHighscoreText.text 		= "NEW HIGHSCORE";
		bonusCoinsText.text 		= "AND GET 150 EXTRA COINS!";
		currentCoinsText.text 		= "CURRENT COINS";
		StartCoroutine(UpdateScore());
		upgradesText.text 			= "BUY UPGRADES";
	}

	IEnumerator UpdateScore(){
		for(int i = 0; i < (Mathf.RoundToInt (player.Distance) / 10); i++){
			currentCoinsNumberText.text = (PlayerPrefs.GetInt ("Score", 0) + i).ToString();

			yield return new WaitForSeconds (0.075f);
		}
	}
}
