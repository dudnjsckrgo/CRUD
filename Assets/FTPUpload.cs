using UnityEngine;
using System.Net;
using System.IO;

public class FTPUpload : MonoBehaviour
{
    public string m_UserName = "ftper";
    public string m_Password = "pkY3yiR;";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            FtpUpload();

        if (Input.GetKeyDown(KeyCode.D))
            FtpDownload();
    }

    void FtpUpload()
    {
        FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://tripleyoung.synology.me:2122/text.txt");
        ftpWebRequest.Credentials = new NetworkCredential(m_UserName, m_Password);
        //ftpWebRequest.EnableSsl = true; // TLS/SSL
        ftpWebRequest.UseBinary = false;   // ASCII, Binary(디폴트)
        ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

        byte[] data = File.ReadAllBytes(@"C:\Users\user\text.txt");

        using (var ftpStream = ftpWebRequest.GetRequestStream())
        {
            ftpStream.Write(data, 0, data.Length);
        }

        using (var response = (FtpWebResponse)ftpWebRequest.GetResponse())
        {
            Debug.Log(response.StatusDescription);
        }
    }

    void FtpDownload()
    {
        FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://tripleyoung.synology.me/text.txt");
        ftpWebRequest.Credentials = new NetworkCredential(m_UserName, m_Password);
        ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;

        using (var localfile = File.Open(@"C:\Users\user\text1.txt", FileMode.Create))
        using (var ftpStream = ftpWebRequest.GetResponse().GetResponseStream())
        {
            byte[] buffer = new byte[1024];
            int n;
            while ((n = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                localfile.Write(buffer, 0, n);
            }
        }
    }
}