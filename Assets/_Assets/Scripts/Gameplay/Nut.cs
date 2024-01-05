using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class Nut : MonoBehaviour
    {
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

        public void Add(Bolt bolt) => _bolts.Push(bolt);

        public void Remove() => _bolts.Pop();

        private bool IsFull()
        {
            //TODO: implement
            return false;
        }
    }
}