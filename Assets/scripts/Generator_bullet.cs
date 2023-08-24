using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_bullet : MonoBehaviour
{
    public GameObject bullet_red_L;
    public GameObject bullet_red_M;
    public GameObject bullet_red_S;
    GameObject bullet;
    int size;
    float x_pos;
    float speed;
    float interval = 0.5f;
    float time;
    float pretime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time - pretime > interval)
        {
            pretime = time;
            interval = Random.Range(0.25f, 1.0f);
            random_fall();
        }
    }

    void random_fall()
    {
        size = Random.Range(1, 4);
        x_pos = Random.Range(-8.0f, 8.0f);
        speed = Random.Range(-4.0f, -0.5f);

        if (size == 1)
        {
            bullet = Instantiate(bullet_red_L, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
        }

        else if(size == 2)
        {
            bullet = Instantiate(bullet_red_M, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
        }

        else
        {
            bullet = Instantiate(bullet_red_S, new Vector3(x_pos, 5.5f, 0), Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
        }
    }
}
