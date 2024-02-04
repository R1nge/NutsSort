using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class Bolt : MonoBehaviour
    {
        [SerializeField] private BoltType boltType;
        public BoltType BoltType => boltType;

        public void Select(Nut currentNut)
        {
            transform.position = currentNut.AbsoluteTopPosition.position;
            //transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360);
        }

        public void MoveTo(Nut nut)
        {
            nut.Add(this);
            transform.position = nut.CurrentTopPosition.position;
        }
    }
}