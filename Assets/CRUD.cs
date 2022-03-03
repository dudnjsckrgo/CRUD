using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System;

namespace YYW
{
    public class CRUD : MonoBehaviour
    {
        void Start()
        {
            if (string.IsNullOrEmpty(HttpServerAddress))
            {
                throw new ArgumentNullException("HttpServerAddress");
            }
            if (!HttpServerAddress.EndsWith("/"))
            {
                HttpServerAddress += "/";
            }
        }
        // Start is called before the first frame update
        string url;

        public string HttpServerAddress = "http://tripleyoung.synology.me:8443/";
        public object apiPath;

        public void Create()
        {
            StopAllCoroutines();
            StartCoroutine(StartCreating());
        }
        public void Upload()
        {
            StopAllCoroutines();
            StartCoroutine(StartUploading());
        }
        public void Read()
        {
            StopAllCoroutines();
            StartCoroutine(StartReading());
        }
        public void Delete()
        {
            StopAllCoroutines();
            StartCoroutine(StartDeleting());
        }
        IEnumerator StartCreating()
        {
            print("ddd");
            ApiMessage msg = null;
            url = "http://tripleyoung.synology.me:8443/api/user";
            var data = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(msg));
            using (UnityWebRequest www = new UnityWebRequest($"{HttpServerAddress}api/{apiPath}", UnityWebRequest.kHttpVerbPOST))
            {
                www.uploadHandler = new UploadHandlerRaw(data);
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
        IEnumerator StartReading()
        {
            print("ddd");
            WWWForm form = new WWWForm();

            url = "http://tripleyoung.synology.me:8443/api/user";
            using (UnityWebRequest www = UnityWebRequest.Get($"{HttpServerAddress}api/{apiPath}"))
            {
                yield return www.SendWebRequest();
                var json = www.downloadHandler.text;

                var msg = JsonUtility.FromJson<ApiMessage>(json);
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
        IEnumerator StartUploading()
        {
            print("ddd");
            WWWForm form = new WWWForm();
            byte[] data = null;
            url = "http://tripleyoung.synology.me:8443/api/user";
            using (UnityWebRequest www = UnityWebRequest.Put($"{HttpServerAddress}api/{apiPath}", data))
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
        IEnumerator StartDeleting()
        {
            print("ddd");
            WWWForm form = new WWWForm();

            url = "http://tripleyoung.synology.me:8443/api/user";
            using (UnityWebRequest www = UnityWebRequest.Delete($"{HttpServerAddress}api/{apiPath}"))
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
}
