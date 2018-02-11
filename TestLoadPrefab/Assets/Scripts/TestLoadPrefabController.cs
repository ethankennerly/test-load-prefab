using UnityEngine;
using UnityEngine.SceneManagement;

namespace Finegamedesign.TestLoadPrefab
{
    public sealed class TestLoadPrefabController : MonoBehaviour
    {
        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
