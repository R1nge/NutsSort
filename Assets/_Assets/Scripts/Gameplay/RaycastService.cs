using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class RaycastService : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var worldMousePosition = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(worldMousePosition, out var hit))
                {
                    if (hit.transform.TryGetComponent(out Nut nut))
                    {
                        nut.OnSelected();
                    }
                }
            }
        }
    }
}