using UnityEngine;

namespace Decorator
{
    public class Player : MonoBehaviour
    {
        private BaseStats _baseStats;
        private IStatsProvide _statsProvide;

        private Race _race;
        private Class _class;
        private Ability _ability;

        public void Initialize(BaseStats baseStats, Race race, Class typeClass, Ability ability)
        {
            _baseStats = baseStats;
            _race = race;
            _class = typeClass;
            _ability = ability;

            _statsProvide = new AbilityStats(_ability, new ClassStats(_class, new RaceStats(_race, _baseStats)));

            ShowParameters();
            _statsProvide.StatProvider(_baseStats);
        }
        public void ShowParameters()
        {
            Debug.Log(_race.ToString());
            Debug.Log(_class.ToString());
            Debug.Log(_ability.ToString());
        }

    }
}
