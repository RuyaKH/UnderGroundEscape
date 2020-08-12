using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountScore : MonoBehaviour {

	public Text scoreText;
	[SerializeField]
	public int scoreValue;
	[SerializeField]
	private int winScore;
	[SerializeField]
	private int playerType;

	// Use this for initialization
	void Start () {
		//Set the score to zero
		scoreValue = 0;
		UpdateScoreText ();
        PlayerPrefs.SetInt("Score", scoreValue);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Alter the score
	public void UpdateScoreValue (int scoreUpdate){
		//Update the score
		scoreValue += scoreUpdate;

		//Update the text of the score in the UI
		UpdateScoreText ();

        //Check if player has won
        /**
		if (scoreValue >= winScore) {
			//Update the playerWin with the public player type variable.
			ApplicationModel.playerWin = playerType;

			//Open the game over scene
			SceneManager.LoadScene("GameOver");
		}
		**/
        PlayerPrefs.SetInt("Score", scoreValue);
    }

	//Update the score in the game
	void UpdateScoreText (){
		scoreText.text = " " + scoreValue;
	}

	//Reset score to zero
	void ResetScore (){
		scoreValue = 0;
		UpdateScoreText();
        PlayerPrefs.SetInt("Score", scoreValue);
    }


}
