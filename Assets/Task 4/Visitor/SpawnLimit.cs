using System.Collections.Generic;

namespace Assets.Visitor
{
    public class SpawnLimit
    {
        //список спавнеров прокидывается через Bootstrap.
        //данная реализация предполагает общий вес для всех спавнеров.
        //второй вариант реализации: поле текущего веса и лимита у каждого спавнера
        private List<Spawner> _spawners;
        private IEnemyDeathNotifier _notifier;
        private int _spawnLimit;
        private SpawnLimitWeight _spawnLimitWeight;
        private int CurrentWeight => _spawnLimitWeight.Weight;


        public SpawnLimit(int spawnLimit, List<Spawner> spawers, IEnemyDeathNotifier enemyDeathNotifier)
        {
            _spawners = spawers;
            _spawnLimit = spawnLimit;
            _notifier = enemyDeathNotifier;

            _notifier.DeathNotified += OnEnemySpawned;

            _spawnLimitWeight = new SpawnLimitWeight();
        }

        private void OnEnemySpawned(Enemy enemy)
        {
            enemy.Accept(_spawnLimitWeight);

            if (CurrentWeight > _spawnLimit)
            {
                foreach (Spawner spawner in _spawners)
                {
                    spawner.StopWork();
                }
            }
        }

        private class SpawnLimitWeight : IEnemyVisitor
        {

            public int Weight { get; private set; }
            public void Visit(Ork ork)
            {
                Weight += 3;
            }

            public void Visit(Human human)
            {
                Weight += 1;
            }

            public void Visit(Elf elf)
            {
                Weight += 2;
            }

            public void Visit(Robot robot)
            {
                Weight += 4;
            }
        }
    }
}
