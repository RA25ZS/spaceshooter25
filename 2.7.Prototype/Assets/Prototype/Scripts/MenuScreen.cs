using Prototype.Base;
using Prototype.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype
{
    public class MenuScreen : BaseScreen
    {
        [SerializeField] TextMeshProUGUI scoreText;

        [SerializeField] BaseScreen settingsScreen;
        public override void Show()
        {
            base.Show();
            scoreText.text = GameInfo.Instance.Scores.ToString();
        }

        public void OnSettingsPressed()
        {
            NextScreen(settingsScreen);
        }

        public void OnGamePressed()
        {
            SceneManager.LoadScene(SceneIds.Game);
        }
    }
}
