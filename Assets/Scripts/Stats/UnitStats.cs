using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Stats
{
    public class UnitStats
    {
        public List<StatsConfig> statsConfigs;

        public UnitStats()
        {
            statsConfigs = new List<StatsConfig>();
            var configs = Resources.LoadAll<StatsConfig>("Configs/StatsConfig");
            for (var i = 0; i < configs.Length; i++)
            {
                statsConfigs.Add(configs[i]);
            }
        }

        public int GetValue(StatsType type, int level)
        {
            var stat = statsConfigs.Find(n => n.statsType == type);
            return (int)stat.levels[level - 1];
        } 
    }
    public class UnitStat
    {
        public StatsType statsType;
        public int value;

        public UnitStat(StatsType type, int value)
        {
            statsType = type;
            this.value = value;
        }
    }
    
}
