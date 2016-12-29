using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void StartGame() {
        GameManager.instance.gameStartedFromMainMenu = true;
		SceneManager.LoadScene("GamePlay");
	}

	public void HighScoreMenu() {
		// Application.LoadLevel("HighScoreScene");
		SceneManager.LoadScene("HighScoreScene");
	}

	public void OptionsMenu() {
		// Application.LoadLevel("OptionsMenuScene");
		SceneManager.LoadScene("OptionsMenuScene");
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void MusicButton() {

	}

}
