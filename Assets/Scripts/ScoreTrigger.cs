using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {
	[SerializeField]
	private CountScore cs;
	[SerializeField]
	private PlayerMovement pm;

	//Check if ball is over the line and update score value
	void OnTriggerEnter2D (Collider2D PlatformCheck){
		Debug.Log ("Player on platform");
		Debug.Log (PlatformCheck.name);

        //Check to see if it is the player that has passed the line
        for (int i = 0; i < 2; i++)
        {
            if (PlatformCheck.name == "Jake")
            {
                cs.UpdateScoreValue(5);
            }
            Debug.Log(gameObject.name);
        }
	
	}
}
