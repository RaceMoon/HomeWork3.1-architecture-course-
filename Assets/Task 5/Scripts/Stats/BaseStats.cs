namespace Decorator
{
    public class BaseStats
    {
        public int Strangth { get; private set; }
        public int Agility { get; private set; }
        public int Intelligence { get; private set; }

        public BaseStats(int strangth, int agility, int intelligence)
        {
            Strangth = strangth;
            Agility = agility;
            Intelligence = intelligence;
        }

        public void AddStrangth(int value)
        {
            Strangth += value;
        }

        public void AddAgility(int value)
        {
            Agility += value;
        }

        public void AddIntelligence(int value)
        {
            Intelligence += value;
        }
    }
}
