using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float base_speed;
    Vector2 speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base_speed = 4.0f;
        speed = new Vector2(0, 0);

        float beside = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(beside == -1)
		{
			//左方向の速度を付ける
			speed += new Vector2(-base_speed, 0);
		}
		
		//Dキーが押されたら
		else if(beside == 1)
		{ 
			speed += new Vector2(base_speed, 0);
		} 

		//Wキーが押されたら
		if(vertical == 1)
		{ 
			speed += new Vector2(0, base_speed);
		} 

		//Sキーが押されたら
		else if(vertical == -1)
		{ 
			speed += new Vector2(0, -base_speed);
		} 

		if(speed.x != 0 && speed.y != 0)
		{
			speed = new Vector2(speed.x / 1.4f, speed.y / 1.4f);	
		}

        if(Input.GetKey("left shift"))
        {
            speed *= 2;
        }

		this.GetComponent<Rigidbody>().velocity = speed;
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            gameover();
        }
    }

    void gameover()
    {
        Destroy(this.gameObject);
    }
}
