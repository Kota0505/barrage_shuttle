using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;

    SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
        this.tag = "Untagged";
        Destroy(this.gameObject, 1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        image = this.gameObject.GetComponent<SpriteRenderer>();
        if (image.sprite.name == "lazer3")
        {
            Debug.Log("bulletになりました");
            this.tag = "bullet";
        }
    }
}
