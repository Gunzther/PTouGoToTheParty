using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilosController : MonoBehaviour
{
    public KeyCode crawl, handsUp;
    public RectTransform canvas;

    Animator anim;
    Vector3 fingerPos;

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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = touch.position;

            if (touch.phase == TouchPhase.Moved)
            {
                pos = touch.position;
            }

            pos.y = (pos.y - canvas.rect.height) / canvas.rect.height;
            fingerPos = new Vector3(0.0f, pos.y, 0.0f);
        }

        if (Input.GetKeyDown(crawl) || fingerPos.y >= 0)
        {
            anim.SetBool("handsUp", false);
            anim.SetBool("crawl", true);
        }
        if (Input.GetKeyUp(crawl) || Input.touchCount == 0)
        {
            anim.SetBool("crawl", false);
        }
        if (Input.GetKeyDown(handsUp) || fingerPos.y < 0)
        {
            anim.SetBool("crawl", false);
            anim.SetBool("handsUp", true);
        }
        if (Input.GetKeyUp(handsUp) || Input.touchCount == 0)
        {
            anim.SetBool("handsUp", false);
        }
    }
}
