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

	public void ShowScoreboard(){
		scoreboardHolder.SetActive (true);
		PlayerPrefs.SetInt ("Score", 1);
		ss.UpdateCoins (Mathf.RoundToInt (player.Distance) / 10);
		SetTexts ();
	}

	void SetTexts(){
		youDroveText.text 			= "YOU DROVE";
		distanceText.text 			= Mathf.RoundToInt(player.Distance) + " m";
		coinsEarnedText.text 		= "AND EARNED " + (Mathf.RoundToInt(player.Distance) / 10)  + " COINS";
		socialNetworkText.text 		= "CHALLENGE YOUR FRIENDS ON";
		newHighscoreText.text 		= "NEW HIGHSCORE";
		bonusCoinsText.text 		= "AND GET 150 EXTRA COINS!";
		currentCoinsText.text 		= "CURRENT COINS";
		currentCoinsNumberText.text = (PlayerPrefs.GetInt ("Score", 0)).ToString();
		upgradesText.text 			= "BUY UPGRADES";
	}
}