using UnityEngine;
using UnityEngine.SceneManagement;

namespace Finegamedesign.TestLoadPrefab
{
    public sealed class LoadSceneController : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
