using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private GvrHead head;
	private Rigidbody rb;
	public float jumpAngleInDegrees = 30.0f;
	private float jumpAngleInRadians;
	public float jumpSpeed = 10.0f;
	private bool onFloor;
	private float lastJumpRequestTime = 0.0f;
	public LevelState state;

	// Use this for initialization
	void Start () {
		GvrViewer.Instance.OnTrigger += PullTrigger;
		head = GameObject.FindObjectOfType<GvrHead> ();
		rb = GetComponent<Rigidbody> ();
		state = GameObject.FindObjectOfType<LevelState> ();
	}

	void PullTrigger () {
		RequestJump ();
	}

	private void RequestJump () {
		lastJumpRequestTime = Time.time;
		rb.WakeUp ();
	}

	private void Jump () {
		if (!state.IsGameOver) {
			jumpAngleInRadians = jumpAngleInDegrees * Mathf.Deg2Rad;	
			Vector3 jumpVector = Vector3.RotateTowards (LookDirection (), Vector3.up, jumpAngleInRadians, 0);
			rb.velocity = jumpVector * jumpSpeed;
		}
	}

	public Vector3 LookDirection () {
		return Vector3.ProjectOnPlane (head.Gaze.direction, Vector3.up);
	}

	void OnCollisionStay (Collision collision) {
		float delta = Time.time - lastJumpRequestTime;
		if (delta < 0.1) {
			Jump ();
			lastJumpRequestTime = 0.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
