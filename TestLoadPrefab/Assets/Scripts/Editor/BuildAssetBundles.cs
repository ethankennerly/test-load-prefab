using System.IO;
using UnityEditor;

namespace Finegamedesign.TestLoadPrefab
{
    public static class BuildAssetBundles
    {
        // Copied from:
        // https://docs.unity3d.com/Manual/AssetBundles-Workflow.html
        [MenuItem("Assets/Build AssetBundles/Windows")]
        private static void BuildAllAssetBundles()
        {
            string assetBundleDirectory = "Assets/AssetBundles";
            if(!Directory.Exists(assetBundleDirectory))
            {
                Directory.CreateDirectory(assetBundleDirectory);
            }
            BuildPipeline.BuildAssetBundles(assetBundleDirectory,
                BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        }
    }
}
