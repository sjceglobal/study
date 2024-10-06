using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSceneChange()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickCounter()
    {
        StartCoroutine(GetCounter());
    }

    IEnumerator GetCounter()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }
    }

    public GameObject id;
    public GameObject password;
    public void OnClickLoginBtn()
    {
        string strID = id.GetComponent<InputField>().text;
        string strPWD = password.GetComponent<InputField>().text;

        List<CommonDefine.serverPacket> packetList = new List<CommonDefine.serverPacket>();
        CommonDefine.serverPacket packet;
        packet.packetType = "userid";
        packet.packetValue = strID;

        CommonDefine.serverPacket packet2;
        packet2.packetType = "userpwd";
        packet2.packetValue = strPWD;

        packetList.Add(packet);
        packetList.Add(packet2);

        NetworkManager.instance.SendServer("login", packetList);
    }
    
}
