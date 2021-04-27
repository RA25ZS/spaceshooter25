using Prototype.Base;
using Prototype.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] BaseScreen settingsScreen;
        [SerializeField] BaseScreen resultScreen;
        public override void Show()
        {
            base.Show();

            GameInfo.Instance.Scores = 10;
        }

        public void OnSettingsPressed()
        {
            NextScreen(settingsScreen);
        }

        public void OnEndGamePressed()
        {
            NextScreen(resultScreen);
        }
    }
}
