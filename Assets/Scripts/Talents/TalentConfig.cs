using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Talents
{
    [CreateAssetMenu(fileName = "TalentConfig", menuName = "Unit/Talent/TalentConfig")]
    public class TalentConfig : ScriptableObject
    {
        public TalentType talentType;
        public List<int> experienceForLevel;
    }
}