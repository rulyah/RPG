using Enums;
using UnityEngine;

namespace Effects
{
    public class EffectConfig : ScriptableObject
    {
        public EffectsType type;
        public Sprite icon;
        public float duration;
    }
}