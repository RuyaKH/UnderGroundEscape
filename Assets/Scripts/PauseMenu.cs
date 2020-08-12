using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Pause");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}