using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject brokenPlatform;

    [SerializeField] private int xMin = 0;
    [SerializeField] private int xMax = 10;

    [SerializeField] private int screenHeight = 10;

    private int lastPlatformHeight = 3;

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        if (Mathf.Ceil(playerPos.y) > lastPlatformHeight)
        {
            lastPlatformHeight = Mathf.CeilToInt(playerPos.y);

            int rng = Random.Range(xMin, xMax);

            int brokenChance = Random.Range(0, 500 - lastPlatformHeight);

            if (brokenChance == 1)
            {
                Instantiate(brokenPlatform, new Vector2(rng, playerPos.y + screenHeight), Quaternion.identity);
            }
            else
            {
                Instantiate(platform, new Vector2(rng, playerPos.y + screenHeight), Quaternion.identity);
            }
        }
    }

}
	
