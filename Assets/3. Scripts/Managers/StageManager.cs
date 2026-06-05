using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TMP_Text nameT;
    public TMP_Text julguricountT;

    private void Awake()
    {
        if(stage == null)
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

        StartCoroutine(UIMovement.UIMove.FadeOut(fadeP, 4f, null));
        StartCoroutine(SetIntro());
    }

    // Update is called once per frame
    void Update()
    {
        julguricountT.text = $"{todaybook.mystory.julguricount}/{todaybook.mystory.storyimage.Length}";
    }

    IEnumerator SetIntro()
    {
        startP.SetActive(true);
        gameP.SetActive(false);
        button.SetActive(true);
        clicktostart.SetActive(false);

        storynameT.text = todaybook.storyname;
        julguriT.text = todaybook.junguri;
        writerT.text = todaybook.storywriter;
        yearT.text = todaybook.storyear;

        foreach(string st in todaybook.topics)
        {
            GameObject b = Instantiate(topicT, topic);
            b.GetComponent<TMP_Text>().text = st;
        }

        nameT.text = todaybook.storyname;

        yield return new WaitForSeconds(10f);

        StartCoroutine(UIMovement.UIMove.FadeIn(clicktostart.GetComponent<CanvasGroup>(), 2.5f, null));
    }

    public void EndIntroB()
    {
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
}
