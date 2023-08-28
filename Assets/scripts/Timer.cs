using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float limit = 7;
    public float timeCount = 0;
    TextMeshPro timelabel;

    // Start is called before the first frame update
    void Start()
    {
        GameObject timer = GameObject.Find("Timer");
        timelabel = timer.GetComponent<TextMeshPro>(); 
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        string timelabel_text = String.Format("{0:0.00}", limit-timeCount);
        //Format("{0}", 変数)で変数の0番目を表示する。{0:0.00}にすると0.00という形に合わせて0番目の変数を表示する
        timelabel.SetText(timelabel_text);
    }
}
