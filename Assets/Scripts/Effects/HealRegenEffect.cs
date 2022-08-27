namespace Effects
{
    public class HealRegenEffect : Effect
    {
        public HealthRegenEffectConfig config;
        public float ticks;

        public HealRegenEffect(HealthRegenEffectConfig config)
        {
            this.config = config;
        }

        public override void Refresh()
        {
            base.Refresh();
        }
    }
}