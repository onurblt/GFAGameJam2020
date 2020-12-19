using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource snowballEffect;
    public AudioSource walkEffect;

    public void PlaySnowballEffect()
    {
        snowballEffect.Play();
    }

    public void PlayWalkEffect()
    {
        if (!walkEffect.isPlaying)
        {
            walkEffect.Play();
        }
    }
}
