using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class VolumeChanger : MonoBehaviour
    {
        private static readonly string firstPlay = "FirstPlay";
        private static readonly string backgroundMusic = "BackgroundMusic";
        private static readonly string soundEffects = "SoundEffects";

        private int firstPlaySave;
        private float backgroundSound, soundEffectSounds;
        [SerializeField] Slider backgroundSlider, soundeffectsSlider;
        [SerializeField] AudioMixer audioMixer;

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

            audioMixer.SetFloat("MusicVolume", backgroundSound);
            audioMixer.SetFloat("SoundsVolume", soundEffectSounds);
        }

        public void SaveSoundBetweenLevels()
        {
            PlayerPrefs.SetFloat(backgroundMusic, backgroundSlider.value);
            PlayerPrefs.SetFloat(soundEffects, soundeffectsSlider.value);
        }

        private void OnApplicationFocus(bool focus)
        {
            if (!focus)
            {
                SaveSoundBetweenLevels();
            }
        }

        public void UpdateSound()
        {
            SetVolumes(Mathf.Lerp(-80, 0, backgroundSlider.value), Mathf.Lerp(-80, 0, soundeffectsSlider.value));
        }

        void SetVolumes(float _musicVol, float _soundsVol)
        {
            audioMixer.SetFloat("MusicVolume", _musicVol);
            audioMixer.SetFloat("SoundsVolume", _soundsVol);
        }
    }
}
