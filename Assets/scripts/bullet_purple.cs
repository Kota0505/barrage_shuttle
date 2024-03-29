using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_purple : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;
    
    int count;
    Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
        count = 0;
        Destroy(this.gameObject, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            if ((collision.gameObject.name == "wall_up") || (collision.gameObject.name == "wall_down"))
            {
                if (count == 2)
                {
                    Destroy(this.gameObject);
                }
                speed = this.GetComponent<Rigidbody>().velocity;
                this.GetComponent<Rigidbody>().velocity = new Vector3(speed.x, -speed.y, 0);
                count += 1;
            }

            else if ((collision.gameObject.name == "wall_left") || (collision.gameObject.name == "wall_right"))
            {
                if (count == 2)
                {
                    Destroy(this.gameObject);
                }
                speed = this.GetComponent<Rigidbody>().velocity;
                this.GetComponent<Rigidbody>().velocity = new Vector3(-speed.x, speed.y, 0);
                count += 1;
            }
        }
    }
}
