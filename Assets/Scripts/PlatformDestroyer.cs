using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestructionPoint;

    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    void Update()
    {
        if (transform.position.y < platformDestructionPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
