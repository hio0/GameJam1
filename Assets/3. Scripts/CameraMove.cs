using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if(target.TryGetComponent<Player>(out Player player))
            {
                float x = 0;
                float y = 0;

                if(player.isfight)
                {
                    x = target.position.x;
                    y = target.position.y + 2f;
                }
                else
                {
                    x = target.position.x + 6.9f;
                    y = gameObject.transform.position.y;
                }

                gameObject.transform.position = new Vector3(x, y, - 10);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.06f, 1000f), transform.position.y, -10);
            }
        }
    }
}
