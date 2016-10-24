using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

	private float speed;
	private float pathLength;
	// Use this for initialization
	void Start () {
		float lifeTime = pathLength / speed;
		Invoke ("Remove", lifeTime);
	}

	void Remove () {
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * speed * Time.deltaTime;
	}

	public void SetVehiclePath (float vehicleSpeed, float vehiclePathLength) {
		speed = vehicleSpeed;
		pathLength = vehiclePathLength;
	}
}
