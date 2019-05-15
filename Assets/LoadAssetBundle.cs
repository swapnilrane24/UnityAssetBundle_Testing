using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundle : MonoBehaviour
{
    public string pathUrl;          //reference to the URL link
    private GameObject warShip;     //gameobject to store instantialed object reference
    AssetBundle myBundle;           //Variable to store AssetBundle reference

    private void Start()
    {
        StartCoroutine(LoadAsset());    //Coroutine to load the AssetBundle
    }

    IEnumerator LoadAsset()
    {
        //create a Unity web request to get the asset bundle from the URL
        UnityWebRequest unityWebRequest = UnityWebRequestAssetBundle.GetAssetBundle(pathUrl);

        //send the request and wait till we get back the response
        yield return unityWebRequest.SendWebRequest();

        //if we get any erro, print the erro
        if (unityWebRequest.isHttpError || unityWebRequest.isNetworkError)
        {
            Debug.Log("Some error with the loading");
        }
        else  //else get the content and store in myBundle
        {
            myBundle = DownloadHandlerAssetBundle.GetContent(unityWebRequest);
            Debug.Log("Loaded asset");
        }

    }

    //method called to spawn the respective game object
    public void SpawnObj(string assetName)//assetName must be same as the Asset in AssetBundle
    {
        if (myBundle != null)
        {
            var prefab = myBundle.LoadAsset(assetName);
            if (warShip) Destroy(warShip);

            warShip = Instantiate((GameObject)prefab, Vector3.zero, Quaternion.identity);
        }

        Debug.Log(myBundle == null ? "Null" : "Fill");
    }

}
