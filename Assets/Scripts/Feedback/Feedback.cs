using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Feedback
{
    public abstract class Feedback : MonoBehaviour
    {
        // if for example we need access to SpriteRenderer, we need acces to it here
        public abstract void CreateFeedback();
        // Reset out state, before start feedback
        public abstract void CompletePreviousFeedback();

        private void OnDestroy()
        {
            CompletePreviousFeedback();
        }
    }
}