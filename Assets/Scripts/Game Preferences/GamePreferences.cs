using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreferences {

    public static string IS_INITIALIZED = "IsInitialized";

    public static string EASY_DIFFICULTY = "EasyDifficulty";
    public static string MEDIUM_DIFFICULTY = "MediumDifficulty";
    public static string HARD_DIFFICULTY = "HardDifficulty";

    public static string EASY_DIFFICULTY_SCORE = "EasyDifficultyScore";
    public static string MEDIUM_DIFFICULTY_SCORE = "MediumDifficultyScore";
    public static string HARD_DIFFICULTY_SCORE = "HardDifficultyScore";

    public static string EASY_DIFFICULTY_COIN_COUNT = "EasyDifficultyCoinCount";
    public static string MEDIUM_DIFFICULTY_COIN_COUNT = "MediumDifficultyCoinCount";
    public static string HARD_DIFFICULTY_COIN_COUNT = "HardDifficultyCoinCount";

    public static string IS_MUSIC_ON = "IsMusicOn";

    public static void Initialize() {
        if (!PlayerPrefs.HasKey(IS_INITIALIZED)) {
            //Defaults to medium difficulty
            SetDifficulty(1);

            // Default to 0
            SetEasyDifficultyCoinScore();
            SetMediumDifficultyCoinScore();
            SetHardDifficultyCoinScore();

            SetEasyDifficultyScore();
            SetMediumDifficultyScore();
            SetHardDifficultyScore();

            // Default to true
            SetMusicEnabled();

            PlayerPrefs.SetInt(IS_INITIALIZED, 1);
        }
    }

    public static void SetDifficulty(int difficulty = 0) {
        switch (difficulty) {
            case 2:
                PlayerPrefs.SetInt(HARD_DIFFICULTY, 1);
                PlayerPrefs.SetInt(MEDIUM_DIFFICULTY, 0);
                PlayerPrefs.SetInt(EASY_DIFFICULTY, 0);
                break;
            case 1:
                PlayerPrefs.SetInt(HARD_DIFFICULTY, 0);
                PlayerPrefs.SetInt(MEDIUM_DIFFICULTY, 1);
                PlayerPrefs.SetInt(EASY_DIFFICULTY, 0);
                break;
            case 0:
            default:
                PlayerPrefs.SetInt(HARD_DIFFICULTY, 0);
                PlayerPrefs.SetInt(MEDIUM_DIFFICULTY, 0);
                PlayerPrefs.SetInt(EASY_DIFFICULTY, 1);
                break;
        }
    }

    public static bool IsHardDifficulty() {
        return PlayerPrefs.GetInt(HARD_DIFFICULTY) == 1;
    }

    public static bool IsMediumDifficulty() {
        return PlayerPrefs.GetInt(MEDIUM_DIFFICULTY) == 1;
    }

    public static bool IsEasyDifficulty() {
        return PlayerPrefs.GetInt(EASY_DIFFICULTY) == 1;
    }

    public static int GetDifficulty() {
        if (PlayerPrefs.GetInt(HARD_DIFFICULTY) == 1) {
            return 2;
        } else if (PlayerPrefs.GetInt(MEDIUM_DIFFICULTY) == 1) {
            return 1;
        } else {
            return 0;
        }
    }

    public static void SetHardDifficultyScore(int score = 0) {
        PlayerPrefs.SetInt(HARD_DIFFICULTY_SCORE, score);
    }

    public static void SetHardDifficultyCoinScore(int score = 0) {
        PlayerPrefs.SetInt(HARD_DIFFICULTY_COIN_COUNT, score);
    }

    public static void SetMediumDifficultyScore(int score = 0) {
        PlayerPrefs.SetInt(MEDIUM_DIFFICULTY_SCORE, score);
    }

    public static void SetMediumDifficultyCoinScore(int score = 0) {
        PlayerPrefs.SetInt(MEDIUM_DIFFICULTY_COIN_COUNT, score);
    }

    public static void SetEasyDifficultyScore(int score = 0) {
        PlayerPrefs.SetInt(EASY_DIFFICULTY_SCORE, score);
    }

    public static void SetEasyDifficultyCoinScore(int score = 0) {
        PlayerPrefs.SetInt(EASY_DIFFICULTY_COIN_COUNT, score);
    }

    public static int GetHardDifficultyScore() {
        return PlayerPrefs.GetInt(HARD_DIFFICULTY_SCORE);
    }

    public static int GetHardDifficultyCoinScore() {
        return PlayerPrefs.GetInt(HARD_DIFFICULTY_COIN_COUNT);
    }

    public static int GetMediumDifficultyScore() {
        return PlayerPrefs.GetInt(MEDIUM_DIFFICULTY_SCORE);
    }

    public static int GetMediumDifficultyCoinScore() {
        return PlayerPrefs.GetInt(MEDIUM_DIFFICULTY_COIN_COUNT);
    }

    public static int GetEasyDifficultyCoinScore() {
        return PlayerPrefs.GetInt(EASY_DIFFICULTY_SCORE);
    }

    public static int GetEasyDifficultyScore() {
        return PlayerPrefs.GetInt(EASY_DIFFICULTY_COIN_COUNT);
    }

    public static void SetMusicEnabled(bool isEnabled = true) {
        if (isEnabled) {
            PlayerPrefs.SetInt(IS_MUSIC_ON, 1);
        } else {
            PlayerPrefs.SetInt(IS_MUSIC_ON, 0);
        }
    }

    public static bool IsMusicEnabled() {
        return PlayerPrefs.GetInt(IS_MUSIC_ON) == 1;
    }

}
