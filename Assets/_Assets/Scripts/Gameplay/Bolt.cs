using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class Bolt : MonoBehaviour
    {
        [SerializeField] private BoltType boltType;
        public BoltType BoltType => boltType;

        public void Select()
        {
            Debug.Log("Bolt selected", this);
            //TODO: play animation
        }

        public void MoveTo(Nut nut)
        {
            nut.Add(this);
            transform.position = nut.CurrentTopPosition.position;
        }
    }
}