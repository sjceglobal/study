using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Tweener : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go.GetComponent<Image>().DOFade(0, 3f);
        //go.transform.DOScale(new Vector3(0, 0, 0), 3f).SetLoops(5, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
