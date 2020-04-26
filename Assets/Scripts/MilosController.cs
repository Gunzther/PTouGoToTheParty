using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilosController : MonoBehaviour
{
    public KeyCode crawl, handsUp;
    public Slider slider;
    public Toggle toggle;

    Animator anim;

    private void Awake()
    {
        anim = transform.GetComponent<Animator>();
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (toggle.isOn)
        {
            if (slider.value <= 3)
            {
                print("down");
                anim.SetBool("handsUp", false);
                anim.SetBool("crawl", true);
            }
            if (slider.value < 8 && slider.value > 3)
            {
                anim.SetBool("crawl", false);
            }
            if (slider.value >= 8)
            {
                anim.SetBool("crawl", false);
                anim.SetBool("handsUp", true);
            }
            if (slider.value < 8 && slider.value > 3)
            {
                anim.SetBool("handsUp", false);
            }
        }
        else
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
}
