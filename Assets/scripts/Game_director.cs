using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_director : MonoBehaviour
{
    //色を設定するためのマテリアル
    public Material red;

    //左上に表示するシャトルランの回数と表示するためのオブジェクト
    int count = -1;
    string text_string; 
    TextMeshPro counter_text;

    //左右のオブジェクトと右上のバツ印のオブジェクト
    GameObject leftside;
    GameObject rightside;
    GameObject cross1;
    GameObject cross2;

    //それぞれのスクリプトオブジェクト
    Timer timer_script;
    public bool right_reached = true;
    public bool left_reached = true;

    public bool late = false;

    //シャトルランのカウントごとの制限時間を保存した辞書
    Dictionary<int, float> limit_dic = new Dictionary<int, float>()
    {
        {0, 9.00f}, {7, 8.00f}, {15, 7.58f}, {23, 7.20f}, {32, 6.86f}, {41, 6.55f}, {51, 6.26f}, {61, 6.00f}, {72, 5.76f},
        {83, 5.54f}, {94, 5.33f}, {106, 5.14f}, {118, 4.97f}, {131, 4.80f}, {144, 4.65f}, {157, 4.50f}, {171, 4.36f},
        {185, 4.24f}, {200, 4.11f}, {215, 4.00f}, {231, 3.89f}
    };

    // Start is called before the first frame update
    void Start()
    {
        //左上のカウンターへ初期値を設定する
        GameObject counter = GameObject.Find("Counter");
        counter_text = counter.GetComponent<TextMeshPro>();
        counter_text.SetText("000");

        //それぞれのオブジェクトをFindで取得
        leftside = GameObject.Find("leftside");
        rightside = GameObject.Find("rightside");
        cross1 = GameObject.Find("cross1");
        cross2 = GameObject.Find("cross2");

        //それぞれのスクリプトを取得
        timer_script = this.gameObject.GetComponent<Timer>();

        //それぞれのオブジェクトを有効、無効にする
        Active_switch("rightside");
        cross1.SetActive(false);
        cross2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(right_reached);
        Debug.Log($"ひだり{left_reached}");
        if (timer_script.limit - timer_script.timeCount < 0)
        {
            timer_script.timeCount = 0;
            count += 1;
            text_string = String.Format("{0:000}", count);
            counter_text.SetText(text_string);
            if (count % 2 == 0)
            {
                if (right_reached == true)
                {
                    Active_switch("leftside");
                    left_reached = false;
                    cross1.SetActive(false);
                    late = false;
                }
                else
                {
                    if (late)
                    {
                        cross2.SetActive(true);
                        gameover();
                    }
                    cross1.SetActive(true);
                    late = true;
                }
            }

            else
            {
                if (left_reached == true)
                {
                    Active_switch("rightside");
                    right_reached = false;
                    cross1.SetActive(false);
                    late = false;
                }
                else
                {
                    if (late)
                    {
                        cross2.SetActive(true);
                        gameover();
                    }
                    cross1.SetActive(true);
                    late = true;
                }
            }

            if (limit_dic.ContainsKey(count))
            {
                timer_script.limit = limit_dic[count];
            }
        }
        else if (cross1.activeSelf)
        {
            if (count % 2 == 0)
            {
                if (right_reached == true)
                {
                    Active_switch("leftside");
                }
                else
                {
                    leftside.SetActive(false);
                    left_reached = false;
                }
            }

            else
            {
                if (left_reached == true)
                {
                    Active_switch("rightside");
                }
                else
                {
                    rightside.SetActive(false);
                    right_reached = false;
                }
            }
        }
    }

    void Active_switch(string name)
    {
        if (name == "leftside")
        {
            leftside.SetActive(true);
            rightside.GetComponent<Renderer>().material.color = red.color;
            rightside.SetActive(false);
        }

        else if (name == "rightside")
        {
            rightside.SetActive(true);
            leftside.GetComponent<Renderer>().material.color = red.color;
            leftside.SetActive(false);
        }

        else
        {
            Debug.Log("引数Error");
        }
    }

    void gameover()
    {
        //時間を止めて、playerを削除する
        Time.timeScale = 0;
        Destroy(this.gameObject);
    }
}
