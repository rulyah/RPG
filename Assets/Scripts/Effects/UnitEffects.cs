using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Effects
{
    public class UnitEffects
    {
        public List<Effect> effects;
        private readonly PlayerController _player;
        

        public UnitEffects(PlayerController player)
        {
            _player = player;
            effects = new List<Effect>();
        }

        public void Refresh()
        {
            for (var i = 0; i < effects.Count; i++)
            {
                if (effects[i].isFinish)
                {
                    RemoveEffect(effects[i]);
                }
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                //AddEffect();
                
                
            }
        }
        
        public void AddEffect(Effect effect)
        {
            effects.Add(effect);
            effect.Execute(_player);
        }

        public void RemoveEffect(Effect effect)
        {
                effects.Remove(effect);
        }

        public float GetStat(StatsType type)
        {
            return 1;
        }
        
        
    }
}