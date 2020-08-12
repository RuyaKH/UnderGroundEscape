using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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
        GameObject score = GameObject.Find("PlayerScoreNum");
        scoreText = score.GetComponent<scoreText>();
        DontDestroyOnLoad(gameObject);
        Debug.Log(gameObject.name + " start");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("loaded " + scene.name);
        if (String.Equals(scene.name, "GameOver", StringComparison.OrdinalIgnoreCase))
        {
            GameObject score = GameObject.Find("PlayerScoreNum");
            scoreText = score.GetComponent<Text>();

            scoreText.text = scoreValue.ToString();
            Debug.Log("set score text to " + scoreValue);
        }

        if (String.Equals(scene.name, "menu", StringComparison.OrdinalIgnoreCase))
        {
            Destroy(gameObject);
        }
    }
	
	//// Update is called once per frame
	//void Update () {
	
	//}

	////Alter the score
	//public void UpdateScoreValue (int scoreUpdate){
	//	//Update the score
	//	scoreValue += scoreUpdate;

	//	//Update the text of the score in the UI
	//	UpdateScoreText ();

 //       //Check if player has won
 //       /**
	//	if (scoreValue >= winScore) {
	//		//Update the playerWin with the public player type variable.
	//		ApplicationModel.playerWin = playerType;

	//		//Open the game over scene
	//		SceneManager.LoadScene("GameOver");
	//	}
	//	**/
 //       PlayerPrefs.SetInt("Score", scoreValue);
 //   }

	////Update the score in the game
	//void UpdateScoreText (){
	//	scoreText.text = " " + scoreValue;
	//}

	////Reset score to zero
	//void ResetScore (){
	//	scoreValue = 0;
	//	UpdateScoreText();
 //       PlayerPrefs.SetInt("Score", scoreValue);
 //   }


}
