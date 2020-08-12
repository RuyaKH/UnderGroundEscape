using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountLife : MonoBehaviour
{

    public Text lifeText;
    [SerializeField]
    public int lifeValue;
    [SerializeField]
    private int loseScore;
    public int scoreValue;

    // Use this for initialization
    void Start()
    {
        //Set the life to 3
        lifeValue = 1;
        UpdateLifeText();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Alter the score
    public void UpdateLifeValue(int lifeUpdate)
    {
        //Update the score
        lifeValue -= lifeUpdate;

        //Update the text of the score in the UI
        UpdateLifeText();

        //Check if player has lost lives
        
		if (loseScore >= lifeValue) {
            //Open the game over scene
            PlayerPrefs.SetInt("Score", scoreValue);
			SceneManager.LoadScene("GameOver");
		}
    }

    //Update the score in the game
    void UpdateLifeText()
    {
        lifeText.text = " " + lifeValue;
    }

    //Reset score to zero
    void ResetLife()
    {
        lifeValue = 3;
        UpdateLifeText();
    }


}
