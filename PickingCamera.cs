using UnityEngine;
using System.Collections;

public class PickingCamera : MonoBehaviour {
	public float smoothTime = 0.3F;
	public float xOffset = 0;
	public float yOffset = 0;
	public float zOffset = 0;
	public CarPicker cPicker;

	private GameObject carInView;
	private Vector3 velocity = Vector3.zero;

	void LateUpdate() {
		carInView = cPicker.currentCarSelected;

		if (carInView != null) {
			Transform target = carInView.transform;

			Vector3 targetPosition = new Vector3 (target.transform.position.x + xOffset, target.position.y + yOffset, target.position.z + zOffset);
			transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smoothTime);
			//this.transform.rotation = target.gameObject.transform.rotation;

		} else {
			return;
		}
	}
}
