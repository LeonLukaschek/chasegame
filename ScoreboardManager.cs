using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreboardManager : MonoBehaviour {

	public GameObject scoreboardHolder;
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

	void Start () {
		scoreboardHolder.SetActive (false);
	}
	

	void Update () {
	
	}

	public void ShowScoreboard(){
		scoreboardHolder.SetActive (true);
	
		SetTexts ();
	}

	void SetTexts(){
		youDroveText.text 			= "YOU DROVE";
		distanceText.text 			= "DIST_PLACEHOLDER";
		coinsEarnedText.text 		= "AND EARNED " + "COINS_EARNED_PLACEHOLDER" + " COINS";
		socialNetworkText.text 		= "CHALLENGE YOUR FRIENDS!";
		newHighscoreText.text 		= "NEW HIGHSCORE";
		bonusCoinsText.text 		= "AND GET 150 EXTRA COINS!";
		currentCoinsText.text 		= "CURRENT COINS";
		currentCoinsNumberText.text = "CURRENT_COINS_PLACEHOLDER";
		upgradesText.text 			= "BUY UPGRADES";
	}
}
