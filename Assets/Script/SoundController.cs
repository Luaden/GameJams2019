using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip growthClip;
    public AudioClip shrinkClip;
    public AudioClip deathClip;
    public AudioClip respawnClip;

    public AudioSource sFX;

    public void Start()
    {
        sFX = GetComponent<AudioSource>();
        Debug.Log("Audio ON for SoundController");
    }


    public void GrowthClip()
    {
        Debug.Log("Growing");

        sFX.PlayOneShot(growthClip);
    }

    public void ShrinkClip()
    {
        sFX.PlayOneShot(shrinkClip);
    }

    public void RespawnClip()
    {
        sFX.PlayOneShot(respawnClip, .1f);
    }

    public void DeathClip()
    {
        sFX.PlayOneShot(deathClip);
    }
}
