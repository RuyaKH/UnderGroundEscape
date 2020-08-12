using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Camera mainCam;

    float shakeAmount = 0f;

    float countdown = 20f;
    void Start()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

   void Update()
   {
        
        
            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                shake(0.1f, 0.2f);
                countdown = 20f;
            }
            else
            {
                Debug.Log(countdown);
            }
        
   }

    public void shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float shakeAmtX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeAmtY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += shakeAmtX;
            camPos.y += shakeAmtY;

            mainCam.transform.position = camPos;

        }

    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }

}