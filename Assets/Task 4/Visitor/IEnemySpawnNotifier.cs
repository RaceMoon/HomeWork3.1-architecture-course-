using System;

namespace Assets.Visitor
{
    public interface IEnemySpawnNotifier
    {
        public event Action<Enemy> SpawnNotified;
    }
}
