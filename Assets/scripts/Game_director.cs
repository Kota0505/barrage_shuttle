using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_director : MonoBehaviour
{
    public Material red;
    int count = -1;
    GameObject leftside;
    GameObject rightside;
    TextMeshPro counter_text;
    string text_string; 

    Timer timer_script;

    Dictionary<int, float> limit_dic = new Dictionary<int, float>()
    {
        {0, 9.00f}, {7, 8.00f}, {15, 7.58f}, {23, 7.20f}, {32, 6.86f}, {41, 6.55f}, {51, 6.26f}, {61, 6.00f}, {72, 5.76f},
        {83, 5.54f}, {94, 5.33f}, {106, 5.14f}, {118, 4.97f}, {131, 4.80f}, {144, 4.65f}, {157, 4.50f}, {171, 4.36f},
        {185, 4.24f}, {200, 4.11f}, {215, 4.00f}, {231, 3.89f}
    };

    // Start is called before the first frame update
    void Start()
    {
        GameObject counter = GameObject.Find("Counter");
        counter_text = counter.GetComponent<TextMeshPro>();
        counter_text.SetText("000");

        leftside = GameObject.Find("leftside");
        rightside = GameObject.Find("rightside");

        timer_script = this.gameObject.GetComponent<Timer>();

        Active_switch("rightside");


    }

    // Update is called once per frame
    void Update()
    {
        if (timer_script.limit - timer_script.timeCount < 0)
        {
            
            timer_script.timeCount = 0;
            count += 1;
            text_string = String.Format("{0:000}", count);
            counter_text.SetText(text_string);
            if (count % 2 == 0)
            {
                Active_switch("leftside");
            }

            else
            {
                Active_switch("rightside");
            }

            if (limit_dic.ContainsKey(count))
            {
                Debug.Log("実行");
                timer_script.limit = limit_dic[count];
            }

            else
            {
                Debug.Log("実行されてないです");
            }
        }
    }

    void Active_switch(string side)
    {
        if (side == "leftside")
        {
            leftside.SetActive(true);
            rightside.GetComponent<Renderer>().material.color = red.color;
            rightside.SetActive(false);

        }

        else if (side == "rightside")
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
}
