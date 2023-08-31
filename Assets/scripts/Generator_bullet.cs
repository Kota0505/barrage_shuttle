using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_bullet : MonoBehaviour
{
    //弾のprefabを保存しておく
    public GameObject bullet_red_L;
    public GameObject bullet_red_M;
    public GameObject bullet_red_S;

    //実際に発射する弾のオブジェクト
    GameObject bullet;
    
    //弾の大きさ、発生するx座標、スピード、発生間隔、
    int size;
    float x_pos;
    float speed;
    float interval = 0.5f;

    //経過時間を保存するオブジェクト
    float time;
    //前回弾を発射した時間を保存するオブジェクト
    float pretime;

    // Start is called before the first frame update
    void Start()
    {
        
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
            interval = Random.Range(0.25f, 1.0f);
            //ランダムに上から垂直に降ってくる関数を呼び出す
            random_fall();
        }
    }


    void random_fall()
    {
        //弾の大きさ、x座標、speedをランダムに決める
        size = Random.Range(1, 4);
        x_pos = Random.Range(-8.0f, 8.0f);
        speed = Random.Range(-4.0f, -0.5f);

        //sizeで分けてprefabから弾のオブジェクトを生成する
        if (size == 1)
        {
            bullet = Instantiate(bullet_red_L, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
        }

        else if(size == 2)
        {
            bullet = Instantiate(bullet_red_M, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
        }

        else
        {
            bullet = Instantiate(bullet_red_S, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
        }

        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
    }
}
