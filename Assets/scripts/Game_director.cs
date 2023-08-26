using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_director : MonoBehaviour
{
    public Material red;
    int count = 0;
    GameObject leftside;
    GameObject rightside;
    TextMeshPro counter_text;
    string text_string; 

    Timer timer_script;

    // Start is called before the first frame update
    void Start()
    {
        GameObject counter = GameObject.Find("Counter");
        counter_text = counter.GetComponent<TextMeshPro>();
        counter_text.SetText("0");

        leftside = GameObject.Find("leftside");
        rightside = GameObject.Find("rightside");

        timer_script = this.gameObject.GetComponent<Timer>();
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
