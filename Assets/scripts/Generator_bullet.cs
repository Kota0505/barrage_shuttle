using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_bullet : MonoBehaviour
{
    //弾のprefabを保存しておく
    public GameObject bullet_red_S;
    public GameObject bullet_red_M;
    public GameObject bullet_red_L;
    public GameObject bullet_green_S;
    public GameObject bullet_green_M;
    public GameObject bullet_green_L;
    public GameObject bullet_orange;
    public GameObject bullet_purple;
    public GameObject lazer_S;
    public GameObject lazer_M;
    public GameObject lazer_L;

    GameObject lazer;

    //実際に発射する弾のオブジェクト
    GameObject bullet;
    
    //弾の大きさ、発生するx座標、スピード、発生間隔、
    int size;
    float x_pos;
    float y_pos;
    float x_speed;
    float y_speed;
    float interval = 0.5f;
    int rotate;

    //どこから弾を発射するかを決める変数
    int dir = 0; 

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

            else if ((15<director_script.count) && (director_script.count<= 32))
            {
                interval = Random.Range(0.25f, 1.0f);
                x_pos = Random.Range(-8.0f, 8.0f);
                normal_lazer(1, x_pos, 0);
                if((23<director_script.count))
                {
                    size = Random.Range(2, 4);
                    x_pos = Random.Range(-8.0f, 8.0f);
                    y_speed = Random.Range(-4.0f, -0.5f);
                    normal_bullet(size, x_pos, 5.5f, 0, y_speed);
                }
            }

            else if ((32<director_script.count) && (director_script.count <= 51))
            {
                size = Random.Range(1, 4);
                interval = Random.Range(0.2f, 0.9f);
                x_pos = Random.Range(-8.0f, 8.0f);
                x_speed = Random.Range(-3.0f, 3.0f);
                y_speed = Random.Range(-4.0f, -0.5f);
                if (director_script.count <42)
                {
                    normal_bullet(size, x_pos, 5.5f, x_speed, y_speed);
                }
                else
                {
                    normal_bullet(size, x_pos, -5.5f, x_speed, -y_speed);
                }
            }

            else if ((51<director_script.count) && (director_script.count <= 72))
            {
                size = Random.Range(2, 4);
                interval = Random.Range(0.2f, 0.8f);
                x_pos = Random.Range(-8.0f, 8.0f);

                if (director_script.count<=61)
                {
                    x_speed = 0;
                }
                else
                {
                    x_speed = Random.Range(-3.0f, 3.0f);
                }

                y_speed = Random.Range(-4.0f, -0.5f);
                dir = Random.Range(0, 2);
                if (dir == 0)
                {
                    normal_bullet(size, x_pos, 5.5f, x_speed, y_speed);
                }
                else
                {
                    normal_bullet(size, x_pos, -5.5f, x_speed, -y_speed);
                }
            }

            else if((72<director_script.count) && (director_script.count <= 83))
            {
                size = Random.Range(1, 4);
                interval = Random.Range(0.1f, 0.7f);
                x_speed = Random.Range(0.5f, 2.0f);
                y_speed = Random.Range(-2.0f, 2.0f);
                dir = Random.Range(2, 4);
                if (dir == 2)
                {
                    normal_bullet(size, -8.0f, 0.0f, x_speed, y_speed);
                }
                else
                {
                    normal_bullet(size, 8.0f, 0.0f, -x_speed, y_speed);
                }
            }

            else if((83<director_script.count) && (director_script.count <= 94))
            {
                interval = 1.2f;
                for(int i = -5; i <=5;i+=2)
                {
                    normal_bullet(2, i, 5.5f, 0, -4.0f);
                    normal_bullet(2, i, -5.5f, 0, 4.0f);
                }
            }

            else if ((94<director_script.count) && (director_script.count <= 118))
            {
                size = Random.Range(2, 4);
                interval = Random.Range(0.1f, 0.7f);
                x_speed = Random.Range(-3.0f, 3.0f);
                y_speed = Random.Range(-3.0f, 3.0f);
                if (106<director_script.count)
                {
                    size = 1;
                    rotate = Random.Range(0, 360);
                    normal_lazer(2, 0, 0, rotate);
                }
                normal_bullet(size, 0, 0, x_speed, y_speed);
            }

            else if((118<director_script.count) && (director_script.count<= 131))
            {
                size = Random.Range(1, 3);
                interval = Random.Range(0.1f, 0.7f);
                x_pos = Random.Range(-8.0f, 8.0f);
                green_bullet(size, x_pos);
            }

            else if((131<director_script.count) && (director_script.count <= 144))
            {
                size = Random.Range(1, 3);
                interval = Random.Range(0.8f, 1.1f);
                for(int i=0;i<2;i++)
                {
                    if (i == 0)
                    {
                        x_pos = -8.0f;
                        x_speed = Random.Range(1.0f, 4.0f);
                    }
                    else
                    {
                        x_pos = 8.0f;
                        x_speed = Random.Range(-4.0f, -1.0f);
                    }
                    for(int j=0;j<2;j++)
                    {
                        if (j == 0)
                        {
                            y_pos = 5.5f;
                            y_speed = Random.Range(-4.0f, -1.0f);
                        }
                        else
                        {
                            y_pos = -5.5f;
                            y_speed = Random.Range(1.0f, 4.0f);
                        }
                        normal_bullet(size, x_pos, y_pos, x_speed, y_speed);

                    }
                }
            }

            else if ((144 < director_script.count) && (director_script.count <= 157))
            {
                interval = Random.Range(0.5f, 0.8f);
                x_pos = Random.Range(-7.0f, 7.0f);
                y_speed = Random.Range(1.0f, 2.0f);
                orange_bullet(x_pos, y_speed);
            }

            else if((157< director_script.count) && (director_script.count <= 171))
            {
                interval = Random.Range(0.8f, 1.3f);
                x_pos = Random.Range(-7.0f, 7.0f);
                y_speed = Random.Range(1.0f, 2.0f);
                orange_bullet(x_pos, y_speed);
                if (director_script.count%2 == 0)
                {
                    normal_lazer(3, 0, 3.5f, 90);
                }
                else
                {
                    normal_lazer(3, 0, -3.5f, 90);
                }
            }

            else if ((171<=director_script.count) && (director_script.count<=200))
            {
                //発射間隔、弾の大きさ、x座標、speedをランダムに決める
                interval = Random.Range(0.05f, 0.1f);
                x_pos = Random.Range(-8.0f, 8.0f);
                y_speed = Random.Range(-10.0f, -7.5f);

                if (director_script.count <186)
                {
                    //ランダムに上から垂直に降ってくる関数を呼び出す
                    normal_bullet(1, x_pos, 5.5f, 0, y_speed);
                }

                else
                {
                    //ランダムに下から垂直に降ってくる関数を呼び出す
                    normal_bullet(1, x_pos, -5.5f, 0, -y_speed);
                }
            }

            else if((200<director_script.count) && (director_script.count<=215))
            {
                interval = Random.Range(0.3f, 0.4f);
                x_speed = Random.Range(-4.0f, 4.0f);
                y_speed = Random.Range(-2.0f, 2.0f);
                purple_bullet(x_speed, y_speed);
            }
            
            else if((215<director_script.count) && (director_script.count<= 231))
            {
                interval = Random.Range(0.8f, 1.0f);
                for(int i=0;i<2;i++)
                {
                    if (i == 0)
                    {
                        x_pos = -8.0f;
                        x_speed = Random.Range(1.0f, 4.0f);
                    }
                    else
                    {
                        x_pos = 8.0f;
                        x_speed = Random.Range(-4.0f, -1.0f);
                    }
                    for(int j=0;j<2;j++)
                    {
                        if (j == 0)
                        {
                            y_pos = 5.5f;
                            y_speed = Random.Range(-4.0f, -1.0f);
                        }
                        else
                        {
                            y_pos = -5.5f;
                            y_speed = Random.Range(1.0f, 4.0f);
                        }
                        normal_bullet(1, x_pos, y_pos, x_speed, y_speed);

                    }
                }

                y_pos = Random.Range(-5.5f, 5.5f);
                normal_lazer(2, 0, y_pos, 90);
            }

            else if ((231<director_script.count) && (director_script.count<=247))
            {
                interval = Random.Range(0.4f, 0.5f);
                size = Random.Range(1, 4);
                x_pos = Random.Range(-8.0f, 8.0f);
                x_speed = Random.Range(-2.0f, 2.0f);
                y_speed = Random.Range(1.0f, 4.0f);
                normal_bullet(size, x_pos, 5.5f, x_speed, -y_speed);
                if (235 < director_script.count)
                {
                    green_bullet(size, x_pos);
                }

                if (239<director_script.count)
                {
                    y_pos = Random.Range(-5.5f, 5.5f);
                    normal_lazer(2, 0, y_pos, 90);   
                }
                if (243 < director_script.count)
                {
                    y_speed = Random.Range(-2.0f, 2.0f);
                    purple_bullet(x_speed, y_speed);
                }
            }

            else if (247<director_script.count)
            {
                Debug.Log("クリア！");
            }
        }
    }


    void normal_bullet(int size, float x_pos, float y_pos, float x_speed, float y_speed)
    {
        //sizeで分けてprefabから弾のオブジェクトを生成する
        if (size == 1)
        {
            bullet = Instantiate(bullet_red_S, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
        }

        else if(size == 2)
        {
            bullet = Instantiate(bullet_red_M, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
        }

        else
        {
            bullet = Instantiate(bullet_red_L, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
        }

        bullet.GetComponent<Rigidbody>().velocity = new Vector3(x_speed, y_speed, 0);
    }

    void normal_lazer(int size, float x_pos, float y_pos, int rotate=0)
    {
        if (size == 1)
        {
            lazer = Instantiate(lazer_S, new Vector3(x_pos, y_pos, 0), Quaternion.Euler(0, 0, rotate));
        }

        else if (size == 2)
        {
            lazer = Instantiate(lazer_M, new Vector3(x_pos, y_pos, 0), Quaternion.Euler(0, 0, rotate));
        }

        else
        {
            lazer = Instantiate(lazer_L, new Vector3(x_pos, y_pos, 0), Quaternion.Euler(0, 0, rotate));
        }
    }

    void green_bullet(int size, float x_pos)
    {
        //sizeで分けてprefabから弾のオブジェクトを生成する
        if (size == 1)
        {
            bullet = Instantiate(bullet_green_S, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
        }

        else if(size == 2)
        {
            bullet = Instantiate(bullet_green_M, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
        }

        else
        {
            bullet = Instantiate(bullet_green_L, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
        }
    }

    void orange_bullet(float x_pos, float y_speed)
    {
        bullet = Instantiate(bullet_orange, new Vector3(x_pos, -5.5f, 0), Quaternion.identity);
        bullet.GetComponent<bullet_orange>().y_speed = y_speed;
        bullet = Instantiate(bullet_orange, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
        bullet.GetComponent<bullet_orange>().y_speed = -y_speed;
    }
    void purple_bullet(float x_speed, float y_speed)
    {
        bullet = Instantiate(bullet_purple, new Vector3(0, 0, 0), Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(x_speed, y_speed, 0);
    }
}
