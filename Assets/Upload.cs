using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.IO;
using UnityEngine.Networking;

public class Upload : MonoBehaviour
{
    Texture2D imageTexture;
    string fieldName;
    string fileName = "defaultImageName";
    string url;

    //Events
    UnityAction<string> OnErrorAction;
    UnityAction<string> OnCompleteAction;


    public static Upload Initialize()
    {
        return new GameObject("Upload").AddComponent<Upload>();
    }

    public Upload SetUrl(string serverUrl)
    {
        this.url = serverUrl;
        return this;
    }

    public Upload SetTexture(Texture2D texture)
    {
        this.imageTexture = texture;
        return this;
    }

    public Upload SetFileName(string filename)
    {
        this.fileName = filename;
        return this;
    }

    public Upload SetFieldName(string fieldName)
    {
        this.fieldName = fieldName;
        return this;
    }

    //events
    public Upload OnError(UnityAction<string> action)
    {
        this.OnErrorAction = action;
        return this;
    }

    public Upload OnComplete(UnityAction<string> action)
    {
        this.OnCompleteAction = action;
        return this;
    }

    public void Upload1()
    {
        //check/validate fields

        //...

        StopAllCoroutines();
        StartCoroutine(StartUploading());
    }

    string filePath;
    void Start()
    {
        print("ddd");

        Upload1();
    }
    IEnumerator StartUploading()
    {
        print("ddd");
        WWWForm form = new WWWForm();
        filePath = "c:/Users/user/text.txt";
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Flush();
            for (int i = 0; i < bytes.Length; i++)
            {
                print(bytes[i]);
            }
            form.AddBinaryData("myimage", bytes, "text.txt");
        }
        url = "http://tripleyoung.synology.me:8443/upload/";
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }


}