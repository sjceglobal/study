using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeCycle : MonoBehaviour
{
    public enum StateBtn
    {
        None = 0,
        Btn1 = 1,
        Btn2 = 2,
        Btn3 = 3,
    }

    public StateBtn sBtn = StateBtn.None;

    void Awake()
    {
        Debug.Log(sBtn);
    }
    // Start is called before the first frame update
    void Start()
    {
        sBtn = StateBtn.Btn1;
        Debug.Log(sBtn);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    void TestFunc()
    {

    }
}
