using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_bullet : MonoBehaviour
{
    //弾のprefabを保存しておく
    public GameObject bullet_red_L;
    public GameObject bullet_red_M;
    public GameObject bullet_red_S;
    public GameObject lazer;

    //実際に発射する弾のオブジェクト
    GameObject bullet;
    
    //弾の大きさ、発生するx座標、スピード、発生間隔、
    int size;
    float x_pos;
    float y_pos;
    float x_speed;
    float y_speed;
    float interval = 0.5f;

    //経過時間を保存するオブジェクト
    float time;
    //前回弾を発射した時間を保存するオブジェクト
    float pretime;

    GameObject director;
    Game_director director_script;

    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("Game_director");
        director_script = director.GetComponent<Game_director>();
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間を保存
        time += Time.deltaTime;
        //前回弾を発射した時間からintervalの時間が経過したら
        if (time - pretime > interval)
        {
            //弾を発射した時間を今に設定
            pretime = time;
            if ((0<=director_script.count) && (director_script.count<=15))
            {
                //発射間隔、弾の大きさ、x座標、speedをランダムに決める
                interval = Random.Range(0.25f, 1.0f);
                size = Random.Range(1, 4);
                x_pos = Random.Range(-8.0f, 8.0f);
                y_speed = Random.Range(-4.0f, -0.5f);

                if (director_script.count <8)
                {
                    //ランダムに上から垂直に降ってくる関数を呼び出す
                    normal_bullet(size, x_pos, 5.5f, 0, y_speed);
                }

                else
                {
                    //ランダムに下から垂直に降ってくる関数を呼び出す
                    normal_bullet(size, x_pos, -5.5f, 0, -y_speed);
                }
            }

            if ((15<director_script.count) && (director_script.count<= 32))
            {
                interval = Random.Range(0.50f, 1.0f);
                x_pos = Random.Range(-8.0f, 8.0f);
                normal_lazer(x_pos, 0);
                if((23<director_script.count))
                {
                    size = Random.Range(1, 3);
                    x_pos = Random.Range(-8.0f, 8.0f);
                    y_speed = Random.Range(-4.0f, -0.5f);
                    normal_bullet(size, x_pos, 5.5f, 0, y_speed);
                }
            }
        }
    }


    void normal_bullet(int size, float x_pos, float y_pos, float x_speed, float y_speed)
    {
        //sizeで分けてprefabから弾のオブジェクトを生成する
        if (size == 1)
        {
            bullet = Instantiate(bullet_red_L, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
        }

        else if(size == 2)
        {
            bullet = Instantiate(bullet_red_M, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
        }

        else
        {
            bullet = Instantiate(bullet_red_S, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
        }

        bullet.GetComponent<Rigidbody>().velocity = new Vector3(x_speed, y_speed, 0);
    }

    void normal_lazer(float x_pos, float y_pos)
    {
        lazer = Instantiate(lazer, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
    }
}
