using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace KnifeHitClone.TweenEffects
{
    public class MainMenuHeaderTween : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI knifeText;
        [SerializeField]
        private TextMeshProUGUI hitText;

        [Header("Tween Settings")]
        [SerializeField]
        private float targetFontSize = 130f;
        [SerializeField]
        private float durationFontCnange = 1f;

        private void Start()
        {
            knifeText.DOFontSize(targetFontSize, durationFontCnange).SetLoops(-1, LoopType.Yoyo);
            hitText.DOFontSize(targetFontSize, durationFontCnange).SetLoops(-1, LoopType.Yoyo);
        }

        private void Update()
        {
            
        }
    }
}