using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    private void Awake() {
        MakeSingleton();
        GamePreferences.Initialize();
    }

    private void OnLevelWasLoaded(int level) {
        Debug.Log("Active Scene: " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name.ToLower() == "gameplay") {
            if (gameRestartAfterPlayerDied) {
                GamePlayController.instance.SetScore(score);
                GamePlayController.instance.SetCoinScore(coinScore);
                GamePlayController.instance.SetLifeScore(lifeScore);

                PlayerScore.SetScoreCount(score);
                PlayerScore.SetCoinCount(coinScore);
                PlayerScore.SetLifeCount(lifeScore);
                  
            } else if (gameStartedFromMainMenu) {
                PlayerScore.SetScoreCount(0);
                PlayerScore.SetCoinCount(0);
                PlayerScore.SetLifeCount(1);

                GamePlayController.instance.SetScore(PlayerScore.GetScoreCount());
                GamePlayController.instance.SetCoinScore(PlayerScore.GetCoinCount());
                GamePlayController.instance.SetLifeScore(PlayerScore.GetLifeCount());
            }
        }
    }

    void MakeSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore) {

        GamePlayController.instance.SetScoreLabelsText(score, coinScore, lifeScore);

        if (lifeScore < 0) {

            if (GamePreferences.IsEasyDifficulty()) {
                int highScore = GamePreferences.GetEasyDifficultyScore();
                int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore();

                if (score > highScore) {
                    GamePreferences.SetEasyDifficultyScore(score);
                }

                if (coinScore > coinHighScore) {
                    GamePreferences.SetEasyDifficultyCoinScore(coinScore);
                }
            }

            if (GamePreferences.IsMediumDifficulty()) {
                int highScore = GamePreferences.GetMediumDifficultyScore();
                int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore();

                if (score > highScore) {
                    GamePreferences.SetMediumDifficultyScore(score);
                }

                if (coinScore > coinHighScore) {
                    GamePreferences.SetMediumDifficultyCoinScore(coinScore);
                }
            }

            if (GamePreferences.IsHardDifficulty()) {
                int highScore = GamePreferences.GetHardDifficultyScore();
                int coinHighScore = GamePreferences.GetHardDifficultyCoinScore();

                if (score > highScore) {
                    GamePreferences.SetHardDifficultyScore(score);
                }

                if (coinScore > coinHighScore) {
                    GamePreferences.SetHardDifficultyCoinScore(coinScore);
                }
            }

            gameStartedFromMainMenu = false;
            gameRestartAfterPlayerDied = false;

            GamePlayController.instance.GameOverShowPanel(score, coinScore);

        } else {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameRestartAfterPlayerDied = true;
            gameStartedFromMainMenu = false;

            GamePlayController.instance.PlayerDiedRestartGame();
        }
    }

}
