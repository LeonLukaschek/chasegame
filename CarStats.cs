using UnityEngine;
using System.Collections;

public class CarStats : MonoBehaviour {
	[SerializeField]
	[Range(0, 10)]
	private float speed;
	[SerializeField]
	[Range(0, 10)]
	private int health;
	[SerializeField]
	private string name;


	/*
	 *
	 *Getter for the Car stats
	 * 
	 */
	public float Speed {
		get {
			return this.speed;
		}
		set {
			speed = value;
		}
	}

	public int Health {
		get {
			return this.health;
		}
		set {
			health = value;
		}
	}

	public string Name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}

	//Saving the stats so that they can be used in other scenes
	public void SaveStats(){
		PlayerPrefs.SetFloat ("Speed", speed);
		PlayerPrefs.SetInt ("Health", health);
		PlayerPrefs.SetString ("Name", name);
	}
}
