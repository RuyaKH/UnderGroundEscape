using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
  // CameraControl camera;
    [SerializeField]
    private GameObject currentCheckpoint;
    [SerializeField]
    private GameObject player;

    //trigger to check for 
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name);
        if (collider.name == "Jake")
        {
            player.transform.position = currentCheckpoint.transform.position;
           // camera.reset();
        }
    }
}
