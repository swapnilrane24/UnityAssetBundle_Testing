using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateAssetBundle : Editor
{
    [MenuItem("Assets/Create Asset Bundle")]
    static void ExportBundle()
    {
        string path = "Assets/AssetBundle";
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);
    }
}
