using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	public void Start () {
		if (autoLoadNextLevelAfter > 0) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadNextLevel () {
		LoadLevelByOffset (1);
	}

	public void LoadLevelByOffset (int indexOffset) {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + indexOffset);
	}
}
