using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public BoxCollider2D hitrange;
    float baseOffsetX;

    public float attacktimer;

    void Start()
    {
        baseOffsetX = hitrange.offset.x;
        hitrange.enabled = false;

        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if(sp.flipX)
        {
            hitrange.offset = new Vector2(-baseOffsetX, 0);
        }
        else
        {
            hitrange.offset = new Vector2(baseOffsetX, 0);
        }

        attacktimer -= Time.deltaTime;
        if(attacktimer <= 0)
        {
            attacktimer = 0;
        }

        if(Input.GetMouseButtonDown(0) && attacktimer <= 0)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        hitrange.enabled = true;
        yield return new WaitForSeconds(0.5f);
        hitrange.enabled = false;
    }

    void ResetTimer()
    {
        attacktimer = 2f;
    }
}
