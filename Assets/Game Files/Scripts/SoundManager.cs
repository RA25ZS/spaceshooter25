using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip levelMusic;
    [SerializeField] AudioSource levelSource;

    public void PlayLevelMusic()
    {
        levelSource.clip = levelMusic;
        levelSource.Play();
    }

    public void PlaySound(AudioClip _sound)
    {
        levelSource.PlayOneShot(_sound); 
    }
}
