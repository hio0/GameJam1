using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IHitted
{
    public int hp { get; set; }
    public GameObject hitsceen;
    public bool iscanrun;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        iscanrun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(StageManager.stage.isfight)
        {
            gameObject.GetComponent<PlayerAttack>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<PlayerAttack>().enabled = false;
        }
    }

    public void Hitted(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            SceneManager.LoadScene("Stage");
        }
    }
}
