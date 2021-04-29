using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource soundSource;

    [SerializeField] AudioClip musicClip;
    [SerializeField] AudioClip buttonClip;

    public void PlayMusic()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlayButtonSound()
    {
        soundSource.PlayOneShot(buttonClip);
    }

    public void PlaySound(AudioClip _sound)
    {
        soundSource.PlayOneShot(_sound);
    }
}
