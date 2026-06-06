using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Story : ScriptableObject
{
    public int storycount;

    public int julguricount;

    public Sprite[] storyimage;

    public string[] julguritext;

    public List<GameObject> fightscene;

    public bool storyend;
}
