using System.Collections.Generic;
using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class RewindService
    {
        private readonly Stack<BoltHistory> _boltHistory = new();

        public void Add(BoltHistory history) => _boltHistory.Push(history);

        public void Rewind()
        {
            if (_boltHistory.TryPop(out var history))
            {
                history.Bolt.MoveTo(history.Previous);
                history.Current.Remove();    
            }
            else
            {
                Debug.LogWarning("Rewind history is empty");
            }
        }
    }
}