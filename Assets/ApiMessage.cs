// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
namespace YYW
{
    [Serializable]
    public class ApiMessage
    {


        /// <summary>
        /// Possible message types as-serialized on the wire to <c>node-dss</c>.
        /// </summary>
        public string VideoFrame;
        public string AudioFrame;
        public Byte[] bytes;

        public bool videoConstraint = false;
        public bool audioConstraint = false;
        public bool bytesConstraint = false;
        public string v;

        public ApiMessage()
        {
        }

        public ApiMessage(string v)
        {
            this.v = v;
        }

        /// <summary>
        /// Convert a message type from <see xref="string"/> to <see cref="Type"/>.
        /// </summary>
        /// <param name="stringType">The message type as <see xref="string"/>.</param>
        /// <returns>The message type as a <see cref="Type"/> object.</returns>
        /// 
        public ApiMessage(string m_videoFrame, string m_audieoFrame, Byte[] m_bytes)
        {
            if (videoConstraint == true)
            {
                VideoFrame = m_videoFrame;
            }
            if (audioConstraint == true)
            {
                AudioFrame = m_audieoFrame;
            }
            if (bytesConstraint == true)
            {
                bytes = m_bytes;
            }

        }


    }
}