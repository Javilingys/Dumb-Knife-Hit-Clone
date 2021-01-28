using KnifeHitClone.Game;
using KnifeHitClone.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.UI
{
    public class GameMenu : Menu<GameMenu>
    {
        [SerializeField]
        private SpriteToggler knifePrefabUI;
        [SerializeField]
        private GameObject knifesPanel;

        private Queue<SpriteToggler> knifes = new Queue<SpriteToggler>();

        private void OnEnable()
        {
            Knife.OnRelease += UpdateKnifeBar;
        }

        private void OnDisable()
        {
            Knife.OnRelease -= UpdateKnifeBar;
        }

        public void SetStartKnifesSet(int knifeCount)
        {
            for (int i = 0; i < knifeCount; i++)
            {
                SpriteToggler knife = Instantiate(knifePrefabUI, knifesPanel.transform);
                knife.SetEnableSprite(true);
                knifes.Enqueue(knife);
            }
        }

        private void UpdateKnifeBar()
        {
            if (knifes.Count > 0)
            {
                SpriteToggler knife = knifes.Dequeue();
                knife.SetEnableSprite(false);
            }
        }
    }
}