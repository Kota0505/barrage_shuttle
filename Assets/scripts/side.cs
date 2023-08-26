using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side : MonoBehaviour
{
    public Material red;
    public Material green;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<Renderer>().material.color = red.color;
        }
    }
}
