using UnityEngine;
using UnityEngine.SceneManagement;

namespace Finegamedesign.TestLoadPrefab
{
    public sealed class LoadController : MonoBehaviour
    {
        public void ClearCache()
        {
            Caching.ClearCache();
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public void LoadResource(string gameObjectPath)
        {
            UnityEngine.Object.Instantiate((GameObject)Resources.Load(gameObjectPath));
        }
    }
}
