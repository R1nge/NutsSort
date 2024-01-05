namespace _Assets.Scripts.Gameplay
{
    public struct BoltHistory
    {
        public Nut Previous;
        public Nut Current;

        public BoltHistory(Nut previous, Nut current)
        {
            Previous = previous;
            Current = current;
        }
    }
}