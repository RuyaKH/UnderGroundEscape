﻿using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public GameObject brokenPlatform;
    public GameObject bluePlatform;
    public float yToSwitchAt;
    public Transform generationPoint;
    public float distanceBetweenY;
    public float distanceBetweenX;

    private float platformHeight;
    public float yMin;
    public float yMax;

    private float platformWidth;
    public float xMin;
    public float xMax;

    void Start()
    {
        platformHeight = platform.GetComponent<BoxCollider2D>().size.y;
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        GameObject platformToPlace = null;

        if (transform.position.y > yToSwitchAt)
        {
            platformToPlace = bluePlatform;
        }
        else
        {
            platformToPlace = platform;
        }
        if (transform.position.y < generationPoint.position.y)
        {
            distanceBetweenY = Random.Range(yMin, yMax);
            distanceBetweenX = Random.Range(xMin, xMax);

            int lastPlatformHeight = Mathf.CeilToInt(transform.position.y);
            int brokenChance = Random.Range(0, 500 - lastPlatformHeight);

            transform.position = new Vector3(distanceBetweenX, transform.position.y + platformHeight + distanceBetweenY, transform.position.z);

            if (brokenChance == 1)
            {
                Instantiate(brokenPlatform, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(platformToPlace, transform.position, transform.rotation);
            }
        }
    }
}
