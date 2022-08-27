    using System;

    public class BattleController
    {
        private PlayerController _player;

        public BattleController(PlayerController player)
        {
            this._player = player;
        }

        public event Action<int> onDamageTake;
        
        
        
        public void TakeDamage(int value)
        {
            _player.currentHealth -= value;
            onDamageTake?.Invoke(_player.currentHealth);
        }

        public void CastSpell(int value)
        {
            _player.currentMana -= value;
            
        }
    }
