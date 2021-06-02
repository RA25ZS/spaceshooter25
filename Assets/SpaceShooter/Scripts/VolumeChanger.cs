using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class VolumeChanger : MonoBehaviour
    {
        private static readonly string backgroundMusic = "BackgroundMusic";
        private static readonly string soundEffects = "SoundEffects";

        [SerializeField] Slider backgroundSlider, soundeffectsSlider;
        [SerializeField] AudioMixer audioMixer;

        public void SaveSoundBetweenLevels()
        {
            PlayerPrefs.SetFloat(backgroundMusic, backgroundSlider.value);
            PlayerPrefs.SetFloat(soundEffects, soundeffectsSlider.value);

            PlayerPrefs.Save();
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
