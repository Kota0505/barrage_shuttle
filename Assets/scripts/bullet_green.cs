using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_green : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;

    float x_speed;
    float y_speed;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
        
        x_speed = Random.Range(-3.0f, 3.0f);
        y_speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        y_speed -= 0.1f;

        this.GetComponent<Rigidbody>().velocity = new Vector3(x_speed, y_speed, 0);
        
        if((this.transform.position.y <-6) || (this.transform.position.y >6) || 
        (this.transform.position.x <-9) || (this.transform.position.x >9))
        {
            Destroy(this.gameObject);
        }
    }
}
