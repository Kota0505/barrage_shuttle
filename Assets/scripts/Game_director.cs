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
    public int count;
    string text_string; 
    TextMeshPro counter_text;

    //左右のオブジェクトと右上のバツ印のオブジェクト、プレイヤーのオブジェクトを取得
    GameObject leftside;
    GameObject rightside;
    GameObject cross1;
    GameObject cross2;
    GameObject pause;
    GameObject player;
    

    //それぞれのスクリプトオブジェクト
    Timer timer_script;
    player player_script;

    //右端と左端にたどり着いたかを表す変数
    public bool right_reached = true;
    public bool left_reached = true;

    //遅れているかどうかの判定に使う変数。trueの状態でもう一度遅れたらゲームオーバー
    public bool late = false;

    AudioSource BGM;

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
        count = -1;

        //左上のカウンターへ初期値を設定する
        GameObject counter = GameObject.Find("Counter");
        counter_text = counter.GetComponent<TextMeshPro>();
        counter_text.SetText("000");

        //それぞれのオブジェクトをFindで取得
        leftside = GameObject.Find("leftside");
        rightside = GameObject.Find("rightside");
        cross1 = GameObject.Find("cross1");
        cross2 = GameObject.Find("cross2");
        pause = GameObject.Find("pause");
        player = GameObject.Find("player");

        //それぞれのスクリプトを取得
        timer_script = this.gameObject.GetComponent<Timer>();
        player_script = player.GetComponent<player>();

        //それぞれのオブジェクトを有効、無効にする
        Active_switch("rightside");
        cross1.SetActive(false);
        cross2.SetActive(false);
        pause.SetActive(false);

        BGM = GetComponent<AudioSource>();

        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"右側{right_reached}");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                BGM.Pause();
                pause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                BGM.UnPause();
                pause.SetActive(false);
            }
        }
        //上のカウントが0になったら
        if (timer_script.limit - timer_script.timeCount <= 0)
        {
            //経過時間を初期化
            timer_script.timeCount = 0;
            //左上のカウントを+1して反映させる
            count += 1;
            text_string = String.Format("{0:000}", count);
            counter_text.SetText(text_string);

            player_script.safe = false;

            //右端に向かって進むとき
            if (count % 2 == 0)
            {
                //右端にたどり着いていたら
                if (right_reached == true)
                {
                    //左側を有効にして右側を無効にする
                    Active_switch("leftside");
                    //左側にたどり着いているかどうかを表す変数を初期化
                    left_reached = false;
                    //バツ印がついていた時用にバツ印を無効にする
                    cross1.SetActive(false);
                    //遅れを取り戻したのでlate変数を初期化する
                    late = false;
                }
                //右側にたどりついていなかったら
                else
                {
                    //もし前回もたどり着くのが遅れていたら
                    if (late)
                    {
                        //二つ目のバツ印を表示してゲームオーバーにする
                        cross2.SetActive(true);
                        gameover();
                    }
                    //一つ目のバツ印を表示して、一回遅れた判定にする
                    cross1.SetActive(true);
                    late = true;
                    left_reached = false;
                }
            }

            //左端に向かって進むとき
            else
            {
                //処理内容は右側の時と同様
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
                    right_reached = false;
                }
            }

            //カウントが辞書のキーに含まれていたら
            if (limit_dic.ContainsKey(count))
            {
                //制限時間を短くする
                timer_script.limit = limit_dic[count];
            }
        }

        //カウントが0ではないがバツ印が1つ付いてた場合(遅れてた場合)
        else if (cross1.activeSelf)
        {
            //右側に向かって進むとき
            if (count % 2 == 0)
            {
                //届いたら左側を表示する
                if (right_reached == true)
                {
                    Active_switch("leftside");
                }
                //届いていなければ、左側を表示しない
                else
                {
                    leftside.SetActive(false);
                }
            }

            //左側に向かって進むとき
            else
            {
                //届いたら右側を表示する
                if (left_reached == true)
                {
                    Active_switch("rightside");
                }
                //届いていなければ、右側を表示しない
                else
                {
                    rightside.SetActive(false);
                    right_reached = false;
                }
            }
        }
    }

    //指定されたオブジェの有効無効を切り替える関数
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

    //ゲームオーバー時に使用する関数
    void gameover()
    {
        //時間を止めて、playerを削除する
        Time.timeScale = 0;
        Destroy(this.gameObject);
    }
}
