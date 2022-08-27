using Enums;

namespace Effects
{
    public class Effect
    {
        public EffectConfig config;
        public bool isFinish = false;
        protected PlayerController _player;
        public virtual void Execute(PlayerController player)
        {
            _player = player;
        }

        public virtual void Refresh()
        {
        }

        public virtual float GetStatAmount(StatsType type) => 0;
        public virtual float GetStatPercent(StatsType type) => 0;

    }
}