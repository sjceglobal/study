using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    #region Singleton
    private static NetworkManager _instance;
    public static NetworkManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = UnityEngine.Object.FindObjectOfType(typeof(NetworkManager)) as NetworkManager;

                GameObject go = new GameObject("NetworkManager");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<NetworkManager>();

            }

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendServer(string api, List<CommonDefine.serverPacket> packetList)
    {
        StartCoroutine(ServerCall(api, packetList));
    }

    IEnumerator ServerCall(string api, List<CommonDefine.serverPacket> packetList)
    {
        string serviceName = "";
        for (int i = 0; i < packetList.Count; ++i)
        {
            if(serviceName.Length > 0)
                serviceName += "&";
            
            CommonDefine.serverPacket packet = packetList[i];
            serviceName += packet.packetType + "=" + packet.packetValue;
        }
        
        string url = CommonDefine.serverURL + api + "?" + serviceName;

        Debug.LogError("before return www");
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        //yield return www;

        Debug.LogError("after return www");

        if (www.error == null && www.isDone)
        {
            Debug.LogError(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("www error : " + www.error);

        }
    }
}
