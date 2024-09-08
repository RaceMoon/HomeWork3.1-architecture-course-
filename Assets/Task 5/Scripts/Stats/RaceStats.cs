using UnityEngine;

namespace Decorator
{
    public class RaceStats : IStatsProvide
    {
        private Race _race;

        public RaceStats(Race race, BaseStats stats)
        {
            _race = race;
        }

        public void StatProvider(BaseStats stats)
        {
            switch (_race)
            {
                case Orc orc:
                    stats.AddStrangth(1);
                    stats.AddAgility(1);
                    stats.AddIntelligence(1);
                    break;

                case Elf elf:
                    stats.AddStrangth(2);
                    stats.AddAgility(2);
                    stats.AddIntelligence(2);
                    break;
                case Human human:
                    stats.AddStrangth(3);
                    stats.AddAgility(3);
                    stats.AddIntelligence(3);
                    break;
            }

            Debug.Log($"Сила: {stats.Strangth}");
            Debug.Log($"Ловкость: {stats.Agility}");
            Debug.Log($"Интеллект: {stats.Intelligence}");
        }
    }
}
