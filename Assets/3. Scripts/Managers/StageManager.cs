using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager stage;
    Book todaybook;
    public CanvasGroup fadeP;

    public GameObject startP;
    public TMP_Text storynameT;
    public TMP_Text julguriT;
    public TMP_Text writerT;
    public TMP_Text yearT;
    public Transform topic;
    public GameObject topicT;
    public GameObject clicktostart;
    public GameObject button;

    public GameObject gameP;
    public PlayerMove player;
    public TMP_Text nameT;
    public TMP_Text julguricountT;
    public TMP_Text nareiterT;

    public GameObject EndP;
    public Transform enemyM;

    public AudioSource bgm;
    public AudioClip wang;
    public AudioClip slept;
    public AudioSource bga;
    public AudioClip bg;

    public bool isfight;

    string log;

    private void Awake()
    {
        if (stage == null)
        {
            stage = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        todaybook = MainManager.main.todaybook;
        todaybook.mystory.storycount = 0;
        todaybook.mystory.julguricount = 0;
        bga.clip = null;

        StartCoroutine(UIMovement.UIMove.FadeOut(fadeP, 5f, null));
        StartCoroutine(SetIntro());
    }

    // Update is called once per frame
    void Update()
    {
        julguricountT.text = $"{todaybook.mystory.storycount + 1}/{todaybook.mystory.fightscene.Count}";

        if(!isfight)
        {
            if (player.gameObject.transform.position.x - player.nextstorypos.x > 5 && todaybook.mystory.julguricount == 0)
            {
                bga.clip = bg;
                bga.Play();

                SetNareiter(todaybook.mystory.julguritext[todaybook.mystory.julguricount]);
                todaybook.mystory.julguricount++;

                player.walks = 0;
            }
            else if (player.gameObject.transform.position.x - player.nextstorypos.x > 30 && todaybook.mystory.julguricount > 0)
            {
                log = todaybook.mystory.julguritext[todaybook.mystory.julguricount];
                if (log.Contains("#"))
                {
                    GameObject a = Instantiate(todaybook.mystory.fightscene[todaybook.mystory.storycount], enemyM);
                    a.transform.position = new Vector2(player.gameObject.transform.position.x + 4, -3.15f);

                    todaybook.mystory.storycount++;
                    isfight = true;
                }

                if (log.Contains('*'))
                {
                    log = null;
                    todaybook.mystory.julguricount++;

                    player.walks = 0;
                }
                else
                {
                    log.Replace("#", "");
                    SetNareiter(log);
                    todaybook.mystory.julguricount++;

                    player.walks = 0;
                }
            }
        }
        else
        {
            if(enemyM.childCount == 0)
            {
                isfight = false;
                player.walks = 0;
            }
        }

        /*
        if(continueT.activeSelf)
        {
            if(Input.GetMouseButtonDown(0))
            {
                WatchStory();
            }
        }
        */
    }

    IEnumerator SetIntro()
    {
        bgm.clip = wang;
        bgm.Play();

        startP.SetActive(true);
        gameP.SetActive(false);

        button.SetActive(true);
        clicktostart.SetActive(false);

        storynameT.text = todaybook.storyname;
        julguriT.text = todaybook.junguri;
        writerT.text = todaybook.storywriter;
        yearT.text = todaybook.storyear;

        foreach (string st in todaybook.topics)
        {
            GameObject b = Instantiate(topicT, topic);
            b.GetComponent<TMP_Text>().text = st;
        }

        nameT.text = todaybook.storyname;

        yield return new WaitForSeconds(10f);

        StartCoroutine(UIMovement.UIMove.FadeIn(clicktostart.GetComponent<CanvasGroup>(), 2f, null));
    }

    public void EndIntroB()
    {
        StopCoroutine("SetIntro");
        StartCoroutine(IntroEnd());
    }

    public IEnumerator IntroEnd()
    {
        button.SetActive(false);
        clicktostart.SetActive(false);
        StartCoroutine(UIMovement.UIMove.FadeOut(startP.GetComponent<CanvasGroup>(), 3, null));

        yield return new WaitForSeconds(4f);

        gameP.SetActive(true);
    }

    void SetNareiter(string t)
    {
        bgm.clip = slept;
        bgm.Play();
        nareiterT.text = t;

        StopCoroutine("TMPFadeInAndOut");
        StartCoroutine(TMPFadeInAndOut(nareiterT, 1.5f));
    }

    IEnumerator TMPFadeInAndOut(TMP_Text text, float fadeTime)
    {
        float time = 0f;
        text.gameObject.SetActive(true);
        text.alpha = 0f;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            text.alpha = Mathf.Lerp(0f, 1f, time / fadeTime);
            yield return null;
        }

        text.alpha = 1f;

        yield return new WaitForSeconds(3f);

        time = 0f;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            text.alpha = Mathf.Lerp(1f, 0f, time / fadeTime);
            yield return null;
        }

        text.alpha = 0f;
        text.gameObject.SetActive(false);
    }

    public void End()
    {
        StartCoroutine(UIMovement.UIMove.FadeIn(EndP.GetComponent<CanvasGroup>(), 1f, null));
    }
}
