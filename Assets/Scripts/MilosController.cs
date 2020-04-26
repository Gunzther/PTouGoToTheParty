using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilosController : MonoBehaviour
{
    public KeyCode crawl, handsUp;
    public Slider slider;

    Animator anim;
    Vector3 fingerPos;

    private void Awake()
    {
        anim = transform.GetComponent<Animator>();
        slider.value = 5;
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(crawl) || slider.value <= 3)
        {
            anim.SetBool("handsUp", false);
            anim.SetBool("crawl", true);
        }
        if (Input.GetKeyUp(crawl) || (slider.value < 8 && slider.value > 3))
        {
            anim.SetBool("crawl", false);
        }
        if (Input.GetKeyDown(handsUp) || slider.value >= 8)
        {
            anim.SetBool("crawl", false);
            anim.SetBool("handsUp", true);
        }
        if (Input.GetKeyUp(handsUp) || (slider.value < 8 && slider.value > 3))
        {
            anim.SetBool("handsUp", false);
        }
    }
}
