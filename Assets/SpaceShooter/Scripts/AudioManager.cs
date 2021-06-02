using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    float masterVolume = 1;
    float musicSound = 1;
    float effectsSound = 1;

    AudioSource[] musicSources;

    public void PlaySound(AudioClip clip, Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(clip, pos, effectsSound * masterVolume);
    }
}
