using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownLoad : MonoBehaviour
{
    private UnityWebRequest uwr;

    public string DownloadImageURL;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Down());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Down()
    {
        DownloadImageURL = "http://tripleyoung.synology.me:8443/download";
        uwr = UnityWebRequest.Get(DownloadImageURL);
        yield return uwr.SendWebRequest();
        print(uwr.downloadHandler.data.Length);
        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            print("Error downloading file: " + uwr.error);
        }
    }
}
