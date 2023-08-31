using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    //limitに制限時間を保存する。GameDirectorによって更新される
    public float limit = 7;

    //timeCountに経過時間を保存する
    public float timeCount = 0;
    TextMeshPro timelabel;

    // Start is called before the first frame update
    void Start()
    {
        //timerオブジェクトを取得する
        GameObject timer = GameObject.Find("Timer");
        timelabel = timer.GetComponent<TextMeshPro>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間をtimeCountに保存
        timeCount += Time.deltaTime;

        //制限時間から経過時間を引いて、カウントダウンを実装する
        //Format("{0}", 変数)で変数の0番目を表示する。{0:0.00}にすると0.00という形に合わせて0番目の変数を表示する
        string timelabel_text = String.Format("{0:0.00}", limit-timeCount);
        timelabel.SetText(timelabel_text);
        
    }
}
