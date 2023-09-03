using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//自分自身が画面外に出たら自信を削除するスクリプト
public class bullet : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
        Destroy(this.gameObject, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if((this.transform.position.y <-6) || (this.transform.position.y >6) || 
        (this.transform.position.x <-9) || (this.transform.position.x >9))
        {
            Destroy(this.gameObject);
        }
    }


}
