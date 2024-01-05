using System.Collections.Generic;

namespace _Assets.Scripts.Gameplay
{
    public class RewindService
    {
        private Stack<BoltHistory> _boltHistory;

        public void Add(BoltHistory history)
        {
            _boltHistory.Push(history);
        }

        public void Rewind(Bolt bolt)
        {
            var previousHistory = _boltHistory.Pop();
            bolt.MoveTo(previousHistory.Previous);
            //TODO: rewind action
        }
    }
}