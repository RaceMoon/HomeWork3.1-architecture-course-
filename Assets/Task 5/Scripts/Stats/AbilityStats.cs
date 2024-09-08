namespace Decorator
{
    public class AbilityStats : IStatsProvide
    {
        private IStatsProvide _statsProvide;
        private Ability _ability;
       
        public AbilityStats(Ability ability, IStatsProvide statsProvide)
        {
            _statsProvide = statsProvide;
            _ability = ability;
        }

        public void StatProvider(BaseStats stats)
        {
            switch (_ability)
            {
                case GodGift godgift:
                    stats.AddStrangth(1);
                    stats.AddAgility(1);
                    stats.AddIntelligence(1);
                    break;

                case HardFist hardFist:
                    stats.AddStrangth(2);
                    stats.AddAgility(2);
                    stats.AddIntelligence(2);
                    break;

                case Secrecy secrecy:
                    stats.AddStrangth(3);
                    stats.AddAgility(3);
                    stats.AddIntelligence(3);
                    break;
            }

            _statsProvide.StatProvider(stats);
        }
    }
}
