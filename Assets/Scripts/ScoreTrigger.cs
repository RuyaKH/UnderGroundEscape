using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	private CountScore cs;

	private PlayerMovement pm;

    int ColNum = 0;

    void Start()
    {
        cs = FindObjectOfType<CountScore>();
        pm = FindObjectOfType<PlayerMovement>();
    }

	void OnTriggerEnter2D (Collider2D PlatformCheck){
		Debug.Log ("Player on platform");
		Debug.Log (PlatformCheck.name);

        if (PlatformCheck.name == "Jake" && ColNum==0)
        {
            cs.UpdateScoreValue(5);                
            Debug.Log(gameObject.name);
            ColNum++;
        }
        else
        {
            ColNum++;
        }
	
	}
}
