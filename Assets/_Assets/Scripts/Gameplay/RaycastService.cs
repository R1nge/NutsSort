using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class RaycastService : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        //TODO: remove it
        [Inject] private RewindService _rewindService;

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

            if (Input.GetMouseButtonDown(1))
            {
                _rewindService.Rewind();
            }
        }
    }
}