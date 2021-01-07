using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    public AudioClip one, two;
    public AudioSource sound;

    public void One()
    {
        sound.PlayOneShot(one);
    }
    public void Two()
    {
        sound.PlayOneShot(two);
    }
}
