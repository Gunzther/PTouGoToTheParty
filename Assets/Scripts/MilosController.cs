using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilosController : MonoBehaviour
{
    public KeyCode crawl, handsUp;

    Animator anim;

    private void Awake()
    {
        anim = transform.GetComponent<Animator>();
        // play bg music
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(crawl))
        {
            anim.SetBool("handsUp", false);
            anim.SetBool("crawl", true);
        }
        if (Input.GetKeyUp(crawl))
        {
            anim.SetBool("crawl", false);
        }
        if (Input.GetKeyDown(handsUp))
        {
            anim.SetBool("crawl", false);
            anim.SetBool("handsUp", true);
        }
        if (Input.GetKeyUp(handsUp))
        {
            anim.SetBool("handsUp", false);
        }
    }
}
