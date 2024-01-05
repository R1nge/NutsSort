namespace _Assets.Scripts.Gameplay
{
    public struct BoltHistory
    {
        public Bolt Bolt;
        public Nut Previous;
        public Nut Current;

        public BoltHistory(Bolt bolt, Nut previous, Nut current)
        {
            Bolt = bolt;
            Previous = previous;
            Current = current;
        }
    }
}