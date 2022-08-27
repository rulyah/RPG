using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "DamageBuffEffectConfig", menuName = "Unit/Effects/DamageBuffEffectConfig")]
    public class DamageBuffEffectConfig : EffectConfig
    {
        public List<StatAmount> statAmounts;
        
        public DamageBuffEffect Create()
        {
            return new DamageBuffEffect(this);
        }
    }
    [Serializable]
    public class StatAmount
    {
        public StatsType statsType;
        public float amount;
        public float percent;
    }  
}