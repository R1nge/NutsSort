using UnityEngine;
using UnityEngine.SceneManagement;

namespace Misc
{
    public class Boot : MonoBehaviour
    {
        private void Start() => SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);
    }
}