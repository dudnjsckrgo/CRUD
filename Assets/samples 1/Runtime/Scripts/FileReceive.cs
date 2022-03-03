using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.WebRTC;
using Microsoft.MixedReality.WebRTC.Unity;
using System.Threading.Tasks;
using System;
public class FileReceive : Signaler
{
    public string outputMsg;
    void Start()
    {
        OnMessageReceived += PeerConnection_OnMessageReceived;
    }
    private void Peer_DataChannelAdded(DataChannel channel)
    {
        try
        {
            channel.MessageReceived += (byte[] message) =>
            {
                _mainThreadWorkQueue.Enqueue(() =>
        {
            OnMessageReceived?.Invoke(message);
        });
            };
        }
        catch (Exception ex)
        {
            outputMsg = "Peer_DataChannelAdded Exception£º" + ex.Message;
        }
    }

    public delegate void DataChannelMessage(byte[] arrMsg);
    public event DataChannelMessage OnMessageReceived;


    private void PeerConnection_OnMessageReceived(byte[] arrMsg)
    {
        try
        {
            //outputMsg = "got a message";
            outputMsg = "File received";
        }
        catch (Exception ex)
        {
            outputMsg = "Exception£º" + ex.Message;
        }
    }

    public override Task SendMessageAsync(SdpMessage message)
    {
        throw new System.NotImplementedException();
    }

    public override Task SendMessageAsync(IceCandidate candidate)
    {
        throw new System.NotImplementedException();
    }
}
