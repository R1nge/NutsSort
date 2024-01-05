using System;
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

        [SerializeField] private Bolt[] bolts;
        private readonly Stack<Bolt> _bolts = new();
        [Inject] private BoltMoverService _boltMoverService;

        private void Start()
        {
            for (int i = 0; i < bolts.Length; i++)
            {
                _bolts.Push(bolts[i]);    
            }
        }

        public void OnSelected()
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

        public void Add(Bolt bolt)
        {
            _bolts.Push(bolt);
        }

        public void Remove(Bolt bolt)
        {
            _bolts.Pop();
        }

        private bool IsFull() => false;

        //TODO: on nut click select the top bolt
    }
}