using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    int HP = 3;
    //基本となるスピード
    float base_speed;

    //実際にプレイヤーに与えられるスピード
    Vector2 speed;

    //プレイヤーが無敵かどうかを表す変数
    public bool safe;

    GameObject director;
    Game_director director_script;

    GameObject life_1;
    GameObject life_2;
    GameObject life_3;

    public Sprite player_image;
    public Sprite player_damage;

    // Start is called before the first frame update
    void Start()
    {
        safe = true;
        base_speed = 4.0f;

        director = GameObject.Find("Game_director");
        director_script = director.GetComponent<Game_director>();
        life_1 = GameObject.Find("life_1");
        life_2 = GameObject.Find("life_2");
        life_3 = GameObject.Find("life_3");
    }

    // Update is called once per frame
    void Update()
    {
        //デバッグ用
        //safe = true;
        
        speed = new Vector2(0, 0);

        //GetAxisRawでWASDと矢印キーでの移動を可能にする。戻り値は-1か1
        float beside = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Aキーが押されたら
        if(beside == -1)
		{
            //右端にたどり着いた時にプレイヤーが左へ動けないようにする（右端にたどり着いていなければ動ける）
            if (!(this.transform.position.x > 7.6 && (director_script.count%2==1 || director_script.count == -1)))
            {
                //左方向の速度を付ける
                speed += new Vector2(-base_speed, 0);
            }
		}
		
		//Dキーが押されたら
		else if(beside == 1)
		{ 
            //左端にたどり着いていなければ右方向へ進める
            if (!(this.transform.position.x < -7.6 && (director_script.count%2==0)))
            {
                //右方向の速度を付ける
			    speed += new Vector2(base_speed, 0);
            }
		} 

		//Wキーが押されたら
		if(vertical == 1)
		{ 
            //上方向の速度を付ける
			speed += new Vector2(0, base_speed);
		} 

		//Sキーが押されたら
		else if(vertical == -1)
		{ 
            //下方向の速度を付ける
			speed += new Vector2(0, -base_speed);
		} 

        //ななめに移動していたら
		if(speed.x != 0 && speed.y != 0)
		{
            //√2で割る（速い移動になってしまうため）
			speed = new Vector2(speed.x / 1.4f, speed.y / 1.4f);	
		}

        //左シフトが押されたら
        if(Input.GetKey("left shift"))
        {
            //speedを二倍にする
            speed *= 2;
        }

        //speedをオブジェクトに与える
		this.GetComponent<Rigidbody>().velocity = speed;
    }

    void OnTriggerEnter(Collider collision)
    {
        //弾に当たったときにプレイヤーが無敵でなければ
        if (collision.gameObject.tag == "bullet" && safe == false)
        {
            if (HP == 1)
            {
                life_1.SetActive(false);
                //ゲームオーバ関数を呼び出す
                gameover();
            }
            else if (HP == 2)
            {
                HP -= 1;
                life_2.SetActive(false);
                StartCoroutine("late_safe_off");
            }
            else if (HP == 3)
            {
                HP -= 1;
                life_3.SetActive(false);
                StartCoroutine("late_safe_off");
            }
        }
    }

    void gameover()
    {
        //時間を止めて、playerを削除する
        Time.timeScale = 0;
        Destroy(this.gameObject);
    }

    IEnumerator late_safe_off()
    {
        safe = true;
        this.GetComponent<SpriteRenderer>().sprite = player_damage;
        yield return new WaitForSeconds(3);
        this.GetComponent<SpriteRenderer>().sprite = player_image;
        safe = false;
    }
}
