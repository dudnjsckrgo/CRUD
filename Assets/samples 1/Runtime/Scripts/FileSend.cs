using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Microsoft.MixedReality.WebRTC;
using Microsoft.MixedReality.WebRTC.Unity;
using System.Threading.Tasks;

public class FileSend : MonoBehaviour
{
    //public PeerConnection2 peerConnection;
    public string filePath;
    public Microsoft.MixedReality.WebRTC.Unity.PeerConnection peerConnection;
    public string outputMsg;
    public DataChannel dataChannel;
    public Microsoft.MixedReality.WebRTC.Unity.Signaler signaler;
    void StartSendFile()
    {

        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Flush();
            SendFile(bytes);
        }
    }
    //Send
    private void OnDataChannelAdded(DataChannel channel)
    {
        Debug.Log($"Added data channel '{channel.Label}' (#{channel.ID}).");
       
    }
    public void SendFile(byte[] data)
    {
        peerConnection.Peer.DataChannelAdded += OnDataChannelAdded;
        try
        {
            if (dataChannel.State == DataChannel.ChannelState.Open)
            {
                dataChannel.SendMessage(data);
            }
            else
                outputMsg = "DataChannel State:" + dataChannel.State.ToString();
        }
        catch (Exception ex)
        {
            outputMsg = "Send File Exception?" + ex.Message;
        }
    }


}


