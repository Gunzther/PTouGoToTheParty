using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public PalletController palletController;
    public GameObject panel;
    public bool gameover;

    int childCount;
    float timer;
    bool shakeAble;
    Animator animTired, animShake;

    private void Awake()
    {
        animTired = panel.GetComponent<Animator>();
        animShake = transform.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        childCount = transform.childCount;
        shakeAble = true;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            timer += Time.deltaTime;
        }

        if (!transform.GetChild(0).gameObject.activeSelf)
        {
            gameover = true;
            print(transform.GetChild(0).name);
            palletController.GameOver(1);
        }

        if(timer >= 17)
        {
            timer = 0;
            shakeAble = true;
            print("tired");
            animShake.SetTrigger("shake");
            for (int i = childCount - 1; i >= 0; i--)
            {
                GameObject child = transform.GetChild(i).gameObject;
                if (child.activeSelf)
                {
                    animTired.SetTrigger("tired");
                    child.SetActive(false);
                    break;
                }
            }
        }

        else if (shakeAble && timer >= 12)
        {
            shakeAble = false;
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    animShake.SetTrigger("shake");
                    print("shake");
                    break;
                }
            }
        }
    }
}
