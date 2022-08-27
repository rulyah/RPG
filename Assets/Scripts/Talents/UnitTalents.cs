using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Talents
{
    public class UnitTalents
    {
        public List<Talent> talents;
        public List<TalentConfig> talentConfigs;

        public UnitTalents()
        {
            talents = new List<Talent>();
            talentConfigs = new List<TalentConfig>();
            var talentConfig = Resources.LoadAll<TalentConfig>("Configs/TalentConfig");
            for (var i = 0; i < talentConfig.Length; i++)
            {
                talents.Add(new Talent(talentConfig[i].talentType));
                talentConfigs.Add(talentConfig[i]);
            }
        }

        public int GetTalentLevel(TalentType talentType)
        {
            return talents[(int)talentType].level;
        }

        public int GetExperience(TalentType talentType)
        {
            return talents[(int)talentType].experience;
        }

        public int GetNeedExperience(TalentType talentType)
        {
            return talentConfigs[(int)talentType].experienceForLevel[GetTalentLevel(talentType)];
        }

        public void AddExperience(TalentType talentType, int value)
        {
            talents[(int)talentType].experience += value;
            Debug.Log($"add {value} exp for {talentType}");
            CheckExperience(talentType);
        }

        public void CheckExperience(TalentType talentType)
        {
            var exp = GetExperience(talentType);
            var needExp = GetNeedExperience(talentType);
            for (var i = talents[(int)talentType].level; exp >= needExp;)
            {
                LevelUpTalent(talentType);
                exp -= needExp;
            }
            
        }
        public int LevelUpTalent(TalentType talentType)
        {
            return talents[(int)talentType].level++;
        }
    }
}