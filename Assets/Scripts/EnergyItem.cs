using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyItem : MonoBehaviour
{
    public List<GameObject> energyBox;
    public int energyValue;
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "hand")
        {
            int count = energyValue;
            foreach(GameObject go in energyBox)
            {
                if (count > 0 && !go.activeSelf)
                {
                    go.SetActive(true);
                    particle.Play();
                    count--;
                }
            }
            transform.gameObject.SetActive(false);
        }
    }
}
