using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fire : MonoBehaviour, IEnemy
{
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        int a = Random.Range(0, 2);
        bool isbool;
        if(a == 0)
        {
            isbool = true;
        }
        else
        {
            isbool = false;
        }
        GetComponent<SpriteRenderer>().flipX = isbool;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool ishit = collision.TryGetComponent<IHitted>(out IHitted hit);

        if (ishit && timer <= 0)
        {
            hit.Hitted(1);
            timer = 1.2f;
        }
    }

    public void Attack()
    {

    }

    public void Dyed()
    {
        
    }

    public void Move()
    {

    }
}
