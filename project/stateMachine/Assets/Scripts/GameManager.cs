using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        character.PlayAnimation(Character.PlayerState.attack);
        monster.SetMonsterSpeed(0f);
        backgroundScroll.SetBackgroundScrollSpeed(0f);
    }

    public void CharacterKilledMonster()
    {
        character.PlayAnimation(Character.PlayerState.run);
        monster.SetMonsterSpeed(2f);
        backgroundScroll.SetBackgroundScrollSpeed(500f);
    }
}
