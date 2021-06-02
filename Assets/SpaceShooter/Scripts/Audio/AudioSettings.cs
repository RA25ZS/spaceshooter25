using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string backgroundMusic = "BackgroundMusic";
    private static readonly string soundEffects = "SoundEffects";
    private float backgroundSound, soundEffectSounds;
    [SerializeField] AudioSource backgroundSoundMusic;
    [SerializeField] AudioSource[] gameEffects;

    private void Awake()
    {
        SavedSettings();
    }

    private void SavedSettings()
    {
        backgroundSound = PlayerPrefs.GetFloat(backgroundMusic);
        soundEffectSounds = PlayerPrefs.GetFloat(soundEffects);

        backgroundSoundMusic.volume = backgroundSound;

        for (int i = 0; i < gameEffects.Length; i++)
        {
            gameEffects[i].volume = soundEffectSounds;
        }
    }
}
