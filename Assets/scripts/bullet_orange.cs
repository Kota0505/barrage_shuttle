using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_orange : MonoBehaviour
{
    public float y_speed;
    float x_speed;
    int cos_speed;

    // Start is called before the first frame update
    void Start()
    {
        cos_speed = Random.Range(2, 12);
    }

    // Update is called once per frame
    void Update()
    {
        x_speed = Mathf.Cos(Time.time*cos_speed);

        this.GetComponent<Rigidbody>().velocity = new Vector3(x_speed, y_speed);
        if((this.transform.position.y <-7) || (this.transform.position.y >7) || 
        (this.transform.position.x <-10) || (this.transform.position.x >10))
        {
            Destroy(this.gameObject);
        }
    }
}
