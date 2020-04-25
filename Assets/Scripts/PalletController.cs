using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PalletController : MonoBehaviour
{
    public float speed, destinaiton;
    public List<Transform> AllTou;
    public GameObject panel, credits;
    public EnergyManager energyManager;
    public GameObject audio1, audio2;
    
    Vector3 movement;
    Rigidbody rb;
    int count, offer;
    bool gameover;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameover = false;
        count = 0;
        offer = 20;
    }

    private void Update()
    {
        if(count < AllTou.Count && transform.position.x - offer >= AllTou[count].position.x)
        {
            AllTou[count].parent = transform;
            count++;
            offer -= 10;
        }
        if (!gameover && transform.position.x >= 670)
        {
            energyManager.gameover = true;
        }
        if (!gameover && transform.position.x >= 730)
        {
            gameover = true;
            audio1.SetActive(false);
            audio2.SetActive(true);
            credits.SetActive(true);
            credits.GetComponent<Animator>().SetTrigger("showCredits");
        }
        if (gameover && Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(0);
    }

    void FixedUpdate()
    {
        if (!gameover && transform.position.x <= destinaiton)
        {
            movement.Set(1f, 0f, 0f);
            movement = movement.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        }
    }

    public void GameOver(int deadCase)
    {
        gameover = true;
        energyManager.gameover = true;
        if(deadCase == 1)
        {
            print(transform.childCount);
            foreach (Transform child in transform)
            {
                child.GetComponent<Animator>().SetBool("tired", true);
            }
        }
        panel.SetActive(true);
    }

}
