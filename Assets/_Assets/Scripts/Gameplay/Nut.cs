using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class Nut : MonoBehaviour
    {
        [SerializeField] private int maxBoltCount;
        [SerializeField] private Transform[] boltsPositions;
        [SerializeField] private Bolt[] bolts;
        private readonly Stack<Bolt> _bolts = new();
        [Inject] private BoltMoverService _boltMoverService;

        public Transform TopPosition => boltsPositions[_bolts.Count - 1];

        private void Start()
        {
            for (int i = 0; i < bolts.Length; i++)
            {
                _bolts.Push(bolts[i]);
                bolts[i].transform.position = boltsPositions[i].position;
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

            if (IsComplete())
            {
                Debug.LogError("Completed");
            }
        }

        public void Remove() => _bolts.Pop();

        public bool IsFull() => _bolts.Count == maxBoltCount;

        public bool IsComplete()
        {
            if (IsFull())
            {
                var list = _bolts.ToList();
                if (list.Any(bolt => bolt.BoltType != list[0].BoltType))
                {
                    Debug.Log("Elements are not the same");
                }
                else
                {
                    Debug.Log("Elements are the same");
                    return true;
                }
            }
            
            return false;
        }

        public bool IsEmpty() => _bolts.Count == 0;
    }
}