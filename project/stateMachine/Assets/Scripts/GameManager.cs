using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using System.Threading;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = UnityEngine.Object.FindObjectOfType(typeof(GameManager)) as GameManager;

                GameObject go = new GameObject("GameManager");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<GameManager>();

            }

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public Character character;
    public Monster monster;
    public BackgroundScroll backgroundScroll;
    public bool isFight = false;
    public int curAttackCnt = 0;
    public UUID uuid = NetworkManager.instance.sessionId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFight)
        {
            if (character.anim.GetCurrentAnimatorStateInfo(0).IsName("character_attack") == true)
            {
                float attackCnt = character.anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
                int cnt = (int)(attackCnt / 1);

                if (cnt > curAttackCnt)
                {
                    curAttackCnt = cnt;
                    AttackMonster();
                }
            }
        }
    }

    struct temp
    {
        public string str1, str2;

        public temp(string str1, string str2)
        {
            this.str1 = str1;
            this.str2 = str2;
        }
    };

    public void CrashCharacterToMonster()
    {
        ReadData("");
        character.PlayAnimation(Character.PlayerState.attack);
        monster.SetMonsterSpeed(0f);
        backgroundScroll.SetBackgroundScrollSpeed(0f);
        isFight = true;
        curAttackCnt = 0;

    }

    public void CharacterKilledMonster()
    {
        character.PlayAnimation(Character.PlayerState.run);
        monster.SetMonsterSpeed(2f);
        backgroundScroll.SetBackgroundScrollSpeed(500f);
        isFight = false;
        List<CommonDefine.serverPacket> packetList = new List<CommonDefine.serverPacket>();
        CommonDefine.serverPacket packet = new CommonDefine.serverPacket("sessionid", NetworkManager.instance.sessionId.sessionId);
        packetList.Add(packet);
        NetworkManager.instance.SendServer("score", packetList);
    }

    public void AttackMonster()
    {
        int attack = character.attack;
        monster.hp -= attack;

        if (monster.hp <= 0)
        {
            CharacterKilledMonster();
        }
    }


    public void ReadData(string path)
    {
        string readFile = "C:\\Users\\User\\Desktop\\dev\\study\\project\\stateMachine\\Assets\\Data\\monsterData.csv";
        FileStream fsOpen = new FileStream(readFile, FileMode.Open);
        StreamReader sr = new StreamReader(fsOpen, Encoding.UTF8, false);
        List<string> strList = new List<string>();

        while (!sr.EndOfStream)
        {
            string s = sr.ReadLine();
            string[] temp = s.Split(',');

            strList.Add(temp[0] + "," + temp[1]);
        }

        monster.hp = int.Parse(strList[0].ToString().Split(',')[1]);
        Debug.Log(strList[0]);
    }
}
