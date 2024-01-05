using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class Nut : MonoBehaviour
    {
        //TODO: use stack for it, as only top element can be swapped
        //TODO: for the revert, should keep a collection of all actions made
        //TODO: Make 'Action' and save it to collection
        //TODO: 'Action' should contain 'previous bolt position (initial)' and 'new bold position'

        private Stack<Bolt> _bolts;
        [Inject] private BoltMoverService _boltMoverService;

        private void OnSelected()
        {
            if (_boltMoverService.HasBoltSelected())
            {
                if (!IsFull())
                {
                    _boltMoverService.MoveTo(this);
                }
            }
            else
            {
                if(_bolts.TryPop(out var bolt))
                {
                    bolt.Select();
                    _boltMoverService.Select(bolt, this);
                }
            }
        }

        private bool IsFull() => false;

        //TODO: on nut click select the top bolt
    }
}