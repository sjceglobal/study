using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(-1 * Time.deltaTime * speed, 0));
    }

    public void SetMonsterSpeed(float setSpeed)
    {
        speed = setSpeed;
    }
}
