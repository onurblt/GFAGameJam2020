using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource snowballEffect;
    public AudioSource walkEffect;
    public AudioSource snowmanRoar;

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

    public void PlaySnowmanRoar()
    {
        if (!snowmanRoar.isPlaying)
        {
            snowmanRoar.Play();
        }
    }
}
