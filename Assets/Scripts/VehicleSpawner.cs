using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] vehiclePrefabs;
	// Use this for initialization
	public float heightOffset = 0.9f;
	public float startOffset = 5f;
	public float speed = 2.0f;
	public float length = 40f;
	public float maxSpawnTime = 10f;

	void Start () {
		StartCoroutine ("Spawn");
	}

	IEnumerator Spawn () {
		while (true) {
			WaitForSeconds randomWait = new WaitForSeconds (Random.Range(1.0f, maxSpawnTime));
			yield return randomWait;
			InstantiateVehicle ();
		}
	}

	void InstantiateVehicle () {
		int vehicleIndex = Random.Range (0, vehiclePrefabs.Length);
		GameObject vehicleObject = Instantiate (vehiclePrefabs[vehicleIndex]);
		vehicleObject.transform.position = GetPositionOffset ();
		vehicleObject.transform.parent = transform;

		Vehicle vehicleComponent = vehicleObject.GetComponent<Vehicle> ();
		vehicleComponent.SetVehiclePath (speed, length);
	}

	Vector3 GetPositionOffset () {
		Vector3 vehicleOffset = new Vector3 (-startOffset, heightOffset, 0);
		Vector3 vehiclePosition = transform.position + vehicleOffset;
		return vehiclePosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
