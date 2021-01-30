using KnifeHitClone.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.UI
{
    public class EndGameMenu : Menu<EndGameMenu>
    {
        public void OnHomePressed()
        {
            StartCoroutine(LoadMainMenu());
        }

        private IEnumerator LoadMainMenu()
        {
            yield return LevelLoader.LoadMainMenuLevel();
            MainMenu.Open();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}