using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Finegamedesign.TestLoadPrefab
{
    public sealed class LoadController : MonoBehaviour
    {
        [SerializeField]
        private string m_StreamingBundlePath = "AssetBundles/testloadprefab";

        private static AssetBundle s_Bundle;

        public void ClearCache()
        {
            Caching.ClearCache();
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            s_Bundle.Unload(true);
            Destroy(s_Bundle);
            s_Bundle = null;
        }

        // Does not load bundle again.
        // Otherwise Unity complains.
        //
        // Does not reuse cached bundle.
        // Otherwise the test performance measurement would be optimized.
        public void LoadAssetFromBundle(string assetName)
        {
            if (s_Bundle == null)
            {
                string path = Path.Combine(Application.streamingAssetsPath, m_StreamingBundlePath);
                AssetBundle bundle = AssetBundle.LoadFromFile(path);
                if (bundle == null)
                {
                    Debug.LogError("Failed to load bundle from streaming file path <" + path + ">");
                    return;
                }
                s_Bundle = bundle;
            }
            GameObject prefab = s_Bundle.LoadAsset<GameObject>(assetName);
            if (prefab == null)
            {
                Debug.LogError("Failed to load asset <" + assetName + "> from bundle <" + s_Bundle + ">");
                return;
            }
            Instantiate(prefab);
        }

        public void LoadResource(string gameObjectPath)
        {
            Instantiate((GameObject)Resources.Load(gameObjectPath));
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
