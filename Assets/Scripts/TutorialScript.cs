using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    void OnTriggerEnter2D (Collider2D collider)
    {
        Debug.Log(collider.name);
        if(collider.name == "Jake")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
