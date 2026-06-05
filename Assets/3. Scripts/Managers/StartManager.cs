using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public Book[] books;

    public CanvasGroup fadep;

    // Start is called before the first frame update
    void Start()
    {
        fadep.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DailyRead()
    {
        bool isok = false;
        
        while(!isok)
        {
            int a = UnityEngine.Random.Range(0, books.Length);

            if(!books[a].mystory.storyend)
            {
                isok = true;
                 MainManager.main.todaybook = books[a];

                Action action = () => SceneManager.LoadScene("Stage");
                StartCoroutine(UIMovement.UIMove.FadeIn(fadep, 1.5f, action));
                break;
            }
            else
            {
                continue;
            }
        }
    }

    public void ReadEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
