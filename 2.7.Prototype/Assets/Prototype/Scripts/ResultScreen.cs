using Prototype.Base;
using Prototype.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype
{
    public class ResultScreen : BaseScreen
    {
        [SerializeField] BaseScreen gameScreen;
        [SerializeField] TextMeshProUGUI scoreText;

        public override void Show()
        {
            base.Show();

            scoreText.text = GameInfo.Instance.Scores.ToString();
        }
        public void OnRestartPressed()
        {
            NextScreen(gameScreen);
        }

        public void OnMenuPressed()
        {
            SceneManager.LoadScene(SceneIds.Menu);
        }
    }
}
