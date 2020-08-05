using UnityEngine;
using System.Collections;

public class SoundHit : MonoBehaviour
{
    [SerializeField]
    new AudioSource soundClip;
    [SerializeField]
    private AudioClip impact;

    void Start() { 
        soundClip = (AudioSource)gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision is happening");
        soundClip.PlayOneShot(impact, 0.7f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger is happening");
        soundClip.PlayOneShot(impact, 0.7f);
    }
}

