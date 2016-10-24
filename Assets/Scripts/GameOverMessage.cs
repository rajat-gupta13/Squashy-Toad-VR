using UnityEngine;
using System.Collections;

public class GameOverMessage : MonoBehaviour {

	public float UIHeight = 1f;
	public float UIDistance = 5f;
	private Player player;
	private Canvas gameOverMessage;
	private LevelState state;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
		gameOverMessage = GetComponent<Canvas> ();
		state = GameObject.FindObjectOfType<LevelState> ();
		gameOverMessage.enabled = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (state.IsGameOver) {
			TrackPlayerHead ();
			gameOverMessage.enabled = true;
		}
	}

	void TrackPlayerHead () {
		transform.rotation = Quaternion.LookRotation (player.LookDirection ());
		transform.position = player.transform.position;
		transform.position += player.LookDirection () * UIDistance;
		transform.position += Vector3.up * UIHeight;
	}
}
