using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Jeja : MonoBehaviour, IEnemy, IHitted
{
    public int hp { get; set; }
    public GameObject text;

    Coroutine cor;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        timer = UnityEngine.Random.Range(3f, 8f);
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Move();
            ResetTimer();
        }
    }

    public void Attack()
    {

    }

    void ResetTimer()
    {
        timer = UnityEngine.Random.Range(15f, 45f);
    }

    public void Dyed()
    {
        StartCoroutine(Dyeing());
    }

    IEnumerator Dyeing()
    {
        Time.timeScale = 0.3f;

        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void Move()
    {
        int a = UnityEngine.Random.Range(0, 3);
        string text = null;
        if(a == 0)
        {
            text = "오, 제발. 이게 무슨 일이야.";
        }
        else if(a == 1)
        {
            text = "선생님? 저기 뱀이 있는데...";
        }
        else if (a == 2)
        {
            text = "이것 좀 풀어주세요!";
        }

        StopCoroutine("TypeText");
        StartCoroutine(TypeText(text));

    }

    IEnumerator TypeText(string text)
    {
        this.text.SetActive(true);
        this.text.GetComponent<TMP_Text>().text = null;
        this.text.GetComponent<TMP_Text>().alpha = 1f;

        foreach (char letter in text.ToCharArray())
        {
            this.text.GetComponent<TMP_Text>().text += letter; // 한 글자씩 추가
            yield return new WaitForSeconds(0.05f); // 글자 사이에 딜레이
        }

        yield return new WaitForSeconds(3f);

        float time = 0f;
        this.text.SetActive(true);
        this.text.GetComponent<TMP_Text>().alpha = 0f;

        while (time < 3f)
        {
            time += Time.deltaTime;
            this.text.GetComponent<TMP_Text>().alpha = Mathf.Lerp(1f, 0f, time / 3f);
            yield return null;
        }

        this.text.GetComponent<TMP_Text>().alpha = 0f;
        this.text.gameObject.SetActive(false);
    }

    public void Hitted(int damage)
    {
        hp -= damage;

        StartCoroutine(Heart());

        if(hp <= 0)
        {
            Dyed();
        }
        else
        {
            int a = UnityEngine.Random.Range(0, 3);
            string text = null;
            if (a == 0)
            {
                text = "아악! 뱀한테 물렸어!";
            }
            else if (a == 1)
            {
                text = "선생님? 여기 피가 좀 나는데...";
            }
            else if (a == 2)
            {
                text = "이것 좀 풀어주세요!, 제발!";
            }

            StartCoroutine(TypeText(text));
        }
    }

    IEnumerator Heart()
    {
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        Color original = spr.color;

        spr.color = new Color32(28, 22, 13, 255);

        yield return new WaitForSeconds(0.2f);

        spr.color = original;
    }
}
