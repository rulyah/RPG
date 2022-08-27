using Enums;

namespace Talents
{
    public class Talent
    {
        public TalentType talentType;
        public int level;
        public int experience;

        public Talent(TalentType talentType)
        {
            this.talentType = talentType;
            level = 1;
            experience = 0;
        }
    }
}
