using System;
using System.Collections;
using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class Bolt : MonoBehaviour
    {
        [SerializeField] private BoltType boltType;
        public BoltType BoltType => boltType;
        public bool Compare(BoltType another) => boltType == another;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(5f);
        }

        public void Select()
        {
            Debug.Log("Bolt selected", this);
        }

        public void MoveTo(Nut nut)
        {
            nut.Add(this);
            transform.position = nut.TopPosition.position;
        }
    }
}