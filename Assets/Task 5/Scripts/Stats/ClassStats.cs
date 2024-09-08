namespace Decorator
{
    public class ClassStats : IStatsProvide
    {
        private IStatsProvide _statsProvide;
        private Class _class;
      
        public ClassStats(Class classType, IStatsProvide statsProvide)
        {
            _statsProvide = statsProvide;
            _class = classType;
        }

        public void StatProvider(BaseStats stats)
        {
            switch (_class)
            {
                case Wizard wizard:
                    stats.AddStrangth(1);
                    stats.AddAgility(1);
                    stats.AddIntelligence(1);
                    break;

                case Barbarian barbarian:
                    stats.AddStrangth(2);
                    stats.AddAgility(2);
                    stats.AddIntelligence(2);
                    break;

                case Thief thief:
                    stats.AddStrangth(3);
                    stats.AddAgility(3);
                    stats.AddIntelligence(3);
                    break;
            }

            _statsProvide.StatProvider(stats);
        }
    }
}
