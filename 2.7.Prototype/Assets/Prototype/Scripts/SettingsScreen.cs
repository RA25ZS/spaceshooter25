using Prototype.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class SettingsScreen : BaseScreen
    {
        [SerializeField] BaseScreen backScreen;
        public void OnBackPressed()
        {
            NextScreen(backScreen);
        }
    }
}
