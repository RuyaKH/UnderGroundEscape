using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject player;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float ypos=-5;

    private float PlayerY;
   
    

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; //calculates an offset value
        
    }
    void Update()
    {
        PlayerY = player.transform.position.y;

    }
    void LateUpdate()
    {
        if (PlayerY > ypos)
        {
            ypos = PlayerY;
            transform.position = new Vector3(player.transform.position.x+offset.x, ypos+offset.y, player.transform.position.z+offset.z);//to which we can add offset values later
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x+offset.x, ypos+offset.y, player.transform.position.z+offset.z);
        }
    }
    public void reset()
    {
        
        transform.position = new Vector3(player.transform.position.x+offset.x, player.transform.position.y+offset.y, player.transform.position.z+offset.z);
    }


}
