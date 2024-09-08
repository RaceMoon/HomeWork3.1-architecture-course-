using UnityEngine;

namespace Decorator
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private BaseStats _baseStats;

        private void Awake()
        {
            _baseStats = new BaseStats(0, 0, 0);

            _player.Initialize(_baseStats, new Human(), new Barbarian(), new Secrecy());
        }
    }
}
