using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class BoltMoverService
    {
        private readonly RewindService _rewindService;
        private Bolt _selectedBolt;
        private Nut _selectedBoltNut;

        private BoltMoverService(RewindService rewindService)
        {
            _rewindService = rewindService;
        }

        public bool HasBoltSelected()
        {
            return _selectedBolt != null;
        }

        public void Select(Bolt bolt, Nut nut)
        {
            _selectedBolt = bolt;
            _selectedBoltNut = nut;
        }

        public void MoveTo(Nut next)
        {
            if (_selectedBolt == null)
            {
                Debug.LogError("Not selected");
            }
            else
            {
                var history = new BoltHistory(_selectedBolt, _selectedBoltNut, next);
                _rewindService.Add(history);
                _selectedBolt.MoveTo(next);
                _selectedBolt = null;
            }
        }
    }
}