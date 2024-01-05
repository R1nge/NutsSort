using System;
using System.Collections;
using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class Bolt : MonoBehaviour
    {
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
            transform.position = nut.transform.position;
            nut.Add(this);
        }
    }
}