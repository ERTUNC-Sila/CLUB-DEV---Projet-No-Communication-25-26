using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace FeedbacksEditor
{
    /// <summary>
    /// Punches the scale of the gameObject
    /// </summary>
    [Serializable]
    public class EffectPunchScale : GameEffect
    {
        public Vector3 PunchScale;
        public float PunchTime;
        public AnimationCurve Curve;
        
        public override IEnumerator Execute(GameEvent gameEvent, GameObject target)
        {
            target.transform.DOPunchScale(PunchScale, PunchTime).SetEase(Curve);
            yield return null;
        }

        public override Color GetColor() => new Color(0.0f, 0.5f, 0.7f);

        public override string ToString()
        {
            return $"Punches the Transform with scale {PunchScale} for {PunchTime} seconds";
        }
    }
}