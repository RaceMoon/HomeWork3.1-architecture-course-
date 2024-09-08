public abstract class Wizard : Enemy
{
    protected abstract void Cast();

    public Wizard()
    {
        Cast();
    }
}
