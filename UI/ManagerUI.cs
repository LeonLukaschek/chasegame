using UnityEngine;
using System.Collections;

public class ManagerUI : MonoBehaviour {

	private GameUI gUI;
	private bool gameOver;
	private ScoreboardManager sm;

	void Start () {
		sm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<ScoreboardManager> ();
		gUI = this.gameObject.GetComponent<GameUI> ();
	}
	

	void Update () {
		if (!gameOver) {
			GameUI ();
		} else {
			GameOverUI ();
		}
	}

	void GameUI(){
		gUI.ShowGameUI (true);
	}

	void GameOverUI(){
		sm.ShowScoreboard ();
		gUI.ShowGameUI (false);
	}

	public bool GameOver {
		get {
			return this.gameOver;
		}
		set {
			gameOver = value;
		}
	}
}
