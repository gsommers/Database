using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadingExample : MonoBehaviour
{
    static AssetBundle myAssetBundle;

    void Start()
    {
        Debug.Log("Hey there");
        myAssetBundle = AssetBundle.LoadFromFile(
            Path.Combine(Application.streamingAssetsPath, "text files"));
        if (myAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle! ");
            return;
        }
    }

    public static AssetBundle GetBundle()
    {
        return myAssetBundle;
    }
}
