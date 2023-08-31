using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side : MonoBehaviour
{
    public Material red;
    public Material green;
    
    GameObject director;
    Game_director director_script;
    GameObject parent;
    GameObject cross1;
    GameObject player;

    player player_script;


    // Start is called before the first frame update
    void Start()
    {

        parent = GameObject.Find("cross_parent");
        // parentはTargetの親のGameObject
        cross1 = parent.transform.Find("cross1").gameObject;

        director = GameObject.Find("Game_director");
        director_script = director.GetComponent<Game_director>();

        player = GameObject.Find("player");
        player_script = player.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        //プレイヤーが端にたどり着いたら
        if(collision.gameObject.tag == "Player")
        {
            //プレイヤーを無敵にする
            player_script.safe = true;
            GetComponent<Renderer>().material.color = green.color;
            //オブジェクトの名前で右と左どっちにたどり着いたかを判定
            if (this.gameObject.name == "rightside")
            {
                director_script.right_reached = true;
            }
            else
            {
                director_script.left_reached = true;
            }
        }
    }
}
