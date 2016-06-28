﻿using UnityEngine;
using System.Collections;
/*
 * 
 * Camera will follow the player smoothly
 * 
 */ 
public class CameraFollow : MonoBehaviour {
	[Header("Camera Follow")]
	public Transform target;
	public float smoothTime = 0.3F;
	public float xOffset = 0;
	public float yOffset = 0;
	public float zOffset = 0;
	private Vector3 velocity = Vector3.zero;

	void LateUpdate() {
		Vector3 targetPosition = new Vector3 (target.position.x + xOffset, target.position.y + yOffset, target.position.z + zOffset);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		//this.transform.rotation = target.gameObject.transform.rotation;
	}

}