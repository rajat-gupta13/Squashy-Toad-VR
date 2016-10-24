using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour {

	private bool _isGameOver = false;

	public bool IsGameOver { 
		get { return _isGameOver; }
		set{
			if (value) {
				SetHighScore ();
			}
			_isGameOver = value;
		}
	}

	private void SetHighScore () {
		GameState state = GameObject.FindObjectOfType<GameState> ();
		Player player = GameObject.FindObjectOfType<Player> ();
		int score = Mathf.FloorToInt (player.transform.position.z);
		state.UpdateHighScore (score);
	}

	public void ResetGame () {
		SceneLoader sceneLoader = GameObject.FindObjectOfType<SceneLoader> ();
		sceneLoader.LoadLevelByOffset (0);
	}

	public void BackToMenu () {
		SceneLoader sceneLoader = GameObject.FindObjectOfType<SceneLoader> ();
		sceneLoader.LoadLevelByOffset (-1);
	}
}
