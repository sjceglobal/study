using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator anim;
    public int anim_cnt = 0;
    public enum PlayerState
    {
        none = 0,
        run = 1,
        attack = 2
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim_cnt >= 10) {
            anim_cnt = 0;
            GameManager.instance.CharacterKilledMonster();
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("character_attack") == true)
        {
            float animTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            float animCnt = animTime / 1;
            anim_cnt = (int)animCnt;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "enemy")
        {
            Debug.Log("====Character Trigger start====");
            GameManager.instance.CrashCharacterToMonster();
        }
    }

    public void PlayAnimation(PlayerState state)
    {
        switch(state)
        {
            case PlayerState.none:
                break;
            case PlayerState.run:
                anim.Play("character_run");
                break;
            case PlayerState.attack:
                anim.Play("character_attack");
                break;
        }

    }

}
