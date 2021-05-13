using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    private static readonly string firstPlay = "FirstPlay";
    private static readonly string backgroundMusic = "BackgroundMusic";
    private static readonly string soundEffects = "SoundEffects";

    private int firstPlaySave;
    private float backgroundSound, soundEffectSounds;
    [SerializeField] Slider backgroundSlider, soundeffectsSlider;
    [SerializeField] AudioSource backgroundSoundMusic;
    [SerializeField] AudioSource[] gameEffects;

    private void Start()
    {
        firstPlaySave = PlayerPrefs.GetInt(firstPlay);

        if (firstPlaySave == 0)
        {
            backgroundSound = 0.25f;
            soundEffectSounds = 0.75f;
            backgroundSlider.value = backgroundSound;
            soundeffectsSlider.value = soundEffectSounds;
            PlayerPrefs.SetFloat(backgroundMusic, backgroundSound);
            PlayerPrefs.SetFloat(soundEffects, soundEffectSounds);
            PlayerPrefs.SetInt(firstPlay, -1);

        }

        else
        {
            backgroundSound = PlayerPrefs.GetFloat(backgroundMusic);
            backgroundSlider.value = backgroundSound;
            soundEffectSounds = PlayerPrefs.GetFloat(soundEffects);
            soundeffectsSlider.value = soundEffectSounds;
        }
    }

    public void SaveSound()
    {
        PlayerPrefs.SetFloat(backgroundMusic, backgroundSlider.value);
        PlayerPrefs.SetFloat(soundEffects, soundeffectsSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSound();
        }
    }

    public void UpdateSound()
    {
        backgroundSoundMusic.volume = backgroundSlider.value;

        for (int i = 0; i < gameEffects.Length; i++)
        {
            gameEffects[i].volume = soundeffectsSlider.value;
        }
    }
}
