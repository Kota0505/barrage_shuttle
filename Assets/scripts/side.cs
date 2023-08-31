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


    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("cross_parent");
        // parentはTargetの親のGameObject
        cross1 = parent.transform.Find("cross1").gameObject;
        director = GameObject.Find("Game_director");
        director_script = director.GetComponent<Game_director>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<Renderer>().material.color = green.color;
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
