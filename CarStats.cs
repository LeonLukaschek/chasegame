using UnityEngine;
using System.Collections;

public class CarStats : MonoBehaviour {
	
	[Range(0.5f, 10f)]
	public float speed;
	[Range(0f, 10f)]
	public float health;

	public string name;

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

	public float Health {
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
		PlayerPrefs.SetFloat ("Lives", health);
		PlayerPrefs.SetString ("Name", name);
	}
}
