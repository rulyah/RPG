using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "HealthRegenEffectConfig", menuName = "Unit/Effects/HealthRegenEffectConfig")]
    public class HealthRegenEffectConfig : EffectConfig
    {
        public float value;

        public HealRegenEffect Create()
        {
            return new HealRegenEffect(this);
        }
    }
}