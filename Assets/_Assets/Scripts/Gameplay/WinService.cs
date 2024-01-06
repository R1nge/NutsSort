using System;
using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class WinService : MonoBehaviour
    {
        [SerializeField] private Nut[] nuts;

        private void Start()
        {
            InvokeRepeating(nameof(CheckIfWin), 1f, 1f);
        }

        private void CheckIfWin()
        {
            var total = nuts.Length;
            var completed = 0;
            var empty = 0;
            for (int i = 0; i < total; i++)
            {
                if (nuts[i].IsComplete())
                {
                    completed++;
                }
                else if (nuts[i].IsEmpty())
                {
                    empty++;
                }
            }

            if (completed + empty == total)
            {
                Debug.LogError("All nuts are completed");
            }
        }
    }
}