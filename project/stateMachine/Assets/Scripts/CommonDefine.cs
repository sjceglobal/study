using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class CommonDefine
{
    public const string serverURL = "http://127.0.0.1:80/";
    public struct serverPacket
    {
        public serverPacket(string type, string value)
        {
            packetType = type;
            packetValue = value;
        }

        public string packetType;
        public string packetValue;
    }
}