using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public PalletController palletController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("gameover");
        collision.transform.parent.GetComponent<Animator>().SetBool("dead", true);
        palletController.GameOver(0);
        // active sound
        // active gameover panel
    }
}
