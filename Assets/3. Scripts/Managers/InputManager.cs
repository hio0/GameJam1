using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagers : MonoBehaviour
{
    public static InputManagers input;

    private void Awake()
    {
        if(input == null)
        {
            input = this;
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
}
