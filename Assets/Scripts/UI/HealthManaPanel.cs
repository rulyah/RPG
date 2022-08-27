using Enums;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthManaPanel : MonoBehaviour
    {
        public PlayerController _player;
        public RectTransform healthTransform;
        public RectTransform manaTransform;
        public TextMeshProUGUI healthText;
        public TextMeshProUGUI manaText;

        public void Init()
        {
            _player.battleController.onDamageTake += BattleControllerOnDamageTake;
            healthRefresh();
        }

        private void BattleControllerOnDamageTake(int currentHealth)
        {
            healthRefresh();
        }

        public void healthRefresh()
        {
            var maxHealth = _player._stats.GetValue(StatsType.MAX_HEALTH,
                _player._talents.GetTalentLevel(TalentType.VITALITY));
            var sizePanel = healthTransform.sizeDelta.x;
            var pos = (sizePanel * (1.0f - (float)_player.currentHealth / (float)maxHealth)) * - 1.0f;
            healthTransform.anchoredPosition += new Vector2(pos, healthTransform.anchoredPosition.y);
            healthText.text = $"{_player.currentHealth.ToString()} / {maxHealth.ToString()}";
        }

    }
}