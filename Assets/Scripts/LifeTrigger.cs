using UnityEngine;
using System.Collections;

public class LifeTrigger : MonoBehaviour
{
    [SerializeField]
    private CountLife cl;
    [SerializeField]
    private PlayerMovement pm;

    //Check if ball is over the line and update score value
    void OnTriggerEnter2D(Collider2D LoseLife)
    {
        Debug.Log("LoseLife");
        Debug.Log(LoseLife.name);

        //Check to see if it is the player that has passed the line
        if (LoseLife.name == "Jake")
        {
            cl.UpdateLifeValue(1);
        }
        Debug.Log(gameObject.name);

    }
}