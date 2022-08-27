using Enums;
using UnityEngine;

namespace Effects
{
    public class DamageBuffEffect : Effect
    {
        public DamageBuffEffectConfig config;
        private float _time;

        public DamageBuffEffect(DamageBuffEffectConfig config)
        {
            this.config = config;
        }

        public override void Refresh()
        {
            if(isFinish) return;
            _time += Time.deltaTime;
            if (_time > config.duration)
            {
                isFinish = true;
                _player.currentHealth += 20;
            }
        }

        public override float GetStatAmount(StatsType type)
        {
            var stat = config.statAmounts.Find(n => n.statsType == type);
            if (stat != null)
            {
                return stat.amount;
            }
            else
            {
                return 0.0f;
            }
        }

        public override float GetStatPercent(StatsType type)
        {
            var stat = config.statAmounts.Find(n => n.statsType == type);
            if (stat != null)
            {
                return stat.percent;
            }
            else
            {
                return 0.0f;
            }
        }
    }
}