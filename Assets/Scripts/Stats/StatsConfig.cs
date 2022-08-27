using System.Collections.Generic;
using Enums;
using UnityEngine;


namespace Stats
{
    [CreateAssetMenu(fileName = "StatsConfig", menuName = "Unit/Stats/StatsConfig")] 
    public class StatsConfig : ScriptableObject
    {
        public TalentType talentType;
        public StatsType statsType;
        public List<float> levels;

        public StatsConfig()
        {
            levels = new List<float>();
            
        }
    }
}
