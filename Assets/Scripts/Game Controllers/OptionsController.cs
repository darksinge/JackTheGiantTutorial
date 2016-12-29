using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionsController : MonoBehaviour {

    private static int HARD = 2;
    private static int MEDIUM = 1;
    private static int EASY = 0;

    [SerializeField]
    private GameObject easySign, mediumSign, hardSign = null;

	void Start () {
        GamePreferences.SetMusicEnabled(true);
        SetInitialDifficulty();
	}
	
    private void SetDifficulty(int diff) {
        if (!(diff == HARD || diff == MEDIUM || diff == EASY))
            diff = EASY;

        hardSign.SetActive(diff == 2);
        mediumSign.SetActive(diff == 1);
        easySign.SetActive(diff == 0);
    }

    private void SetInitialDifficulty() {
        SetDifficulty(GamePreferences.GetDifficulty());
    }

    public void HardDifficulty() {
        GamePreferences.SetDifficulty(HARD);
        SetDifficulty(HARD);
    }

    public void MediumDifficulty() {
        GamePreferences.SetDifficulty(MEDIUM);
        SetDifficulty(MEDIUM);
    }

    public void EasyDifficulty() {
        GamePreferences.SetDifficulty(EASY);
        SetDifficulty(EASY);
    }

	public void GoBackToMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

}
