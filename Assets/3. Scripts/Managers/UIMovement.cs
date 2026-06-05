using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    public static UIMovement UIMove;
    private void Awake()
    {
        if (UIMove == null)
        {
            UIMove = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeIn(CanvasGroup what, float fadeTime, Action action)
    {
        float time = 0f;
        what.gameObject.SetActive(true);
        what.alpha = 0f;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            what.alpha = Mathf.Lerp(0f, 1f, time / fadeTime);
            yield return null;
        }

        what.alpha = 1f;

        yield return new WaitForSeconds(0.5f);
        action?.Invoke();
    }

    public IEnumerator FadeOut(CanvasGroup what, float fadeTime, Action action)
    {
        float time = 0f;
        what.gameObject.SetActive(true);
        what.alpha = 1f;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            what.alpha = Mathf.Lerp(1f, 0f, time / fadeTime);
            yield return null;
        }

        what.alpha = 0f;
        what.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        action?.Invoke();
    }
}
