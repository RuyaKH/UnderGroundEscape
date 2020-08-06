using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public Button playAgainButton;
    public Button endGameButton;

    void Start()
    {
        playAgainButton = playAgainButton.GetComponent<Button>();
        endGameButton = endGameButton.GetComponent<Button>();
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
