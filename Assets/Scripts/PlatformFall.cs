using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called when colliding
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Jake"))
        {
            Invoke("DropPlatform", 1f);
            Destroy(gameObject, 2f);
        }
    }
    void DropPlatform()
    {
        rb2d.isKinematic = false;
    }
}
