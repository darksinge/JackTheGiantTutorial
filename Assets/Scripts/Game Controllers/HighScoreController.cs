using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour {

    [SerializeField]
    private Text scoreText, coinText;

	// Use this for initialization
	void Start () {
        SetScoreBasedOnDifficulty();
    }

    private void SetScore(int score, int coinScore) {
        this.scoreText.text = score.ToString();
        this.coinText.text = coinScore.ToString();
    }

	public void GoBackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
	}

    public void SetScoreBasedOnDifficulty() {
        if (GamePreferences.IsHardDifficulty()) {
            SetScore(GamePreferences.GetHardDifficultyScore(), GamePreferences.GetHardDifficultyCoinScore());
        }

        if (GamePreferences.IsMediumDifficulty()) {
            SetScore(GamePreferences.GetMediumDifficultyScore(), GamePreferences.GetMediumDifficultyCoinScore());
        }

        if (GamePreferences.IsEasyDifficulty()) {
            SetScore(GamePreferences.GetEasyDifficultyScore(), GamePreferences.GetEasyDifficultyCoinScore());
        }
    }

}
