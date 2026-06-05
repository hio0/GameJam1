using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Book : ScriptableObject
{
    [Header("책 정보")]
    public string storyname;

    public string storyear;

    public string[] topics;

    [TextArea]
    public string junguri;

    public string storywriter;

    public Story mystory;
}
