using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    bool isMoving = false;
    float movementDir;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position,Vector2.one * 15f,0f);
        foreach(Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player") && isMoving == false)
            {
                float direction = Mathf.Sign(collider.transform.position.x - transform.position.x);
                rb2d.AddForce(new Vector2(5f, 0f) * direction, ForceMode2D.Impulse);
                isMoving = true;
                movementDir = direction;
            }
        }

        if(movementDir > 0 && rb2d.velocity.x <=0.5f)
        {
            isMoving = false;
        }else if(movementDir < 0 && rb2d.velocity.x >= -0.5f)
        {
            isMoving = false;
        }

    }
}
