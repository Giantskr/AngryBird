using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yell : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip yell1;
    public AudioClip yell2;
    public AudioClip yell3;
    public int whichSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Yelling()
    {
        
        switch(whichSound%3)
        {
            case 1:
                audioSource.PlayOneShot(yell1);
                whichSound += 1;
                break;
            case 2:
                audioSource.PlayOneShot(yell2);
                whichSound += 1;
                break;
            case 0:
                audioSource.PlayOneShot(yell3);
                whichSound += 1;
                break;
        }
            
    }
}
