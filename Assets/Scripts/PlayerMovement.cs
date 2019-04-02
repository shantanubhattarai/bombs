using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    public float maxHP = 100;
    public float currentHP;
    public Kill killer;

    private Rigidbody2D rb2d;
    private SpriteRenderer spr;

    public GameObject deathEffect;
    public float movementSpeed;
    private bool isDashing = false;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(currentHP <= 0)
        {
            killer.KillSth(this.gameObject);
        }

        float h = Input.GetAxisRaw("Horizontal");
        if(!isDashing) rb2d.velocity = (new Vector2(h * movementSpeed, rb2d.velocity.y));
        if (Input.GetButtonDown("Dash"))
        {
            isDashing = true;
            if (h == 0f)
            {
                rb2d.AddForce(Vector2.right * 10f,ForceMode2D.Impulse);
            }
            else
            {
                rb2d.AddForce(Vector2.right * h * 10f,ForceMode2D.Impulse);
            }
            spr.color = Color.yellow;
            Invoke("ResetDash", 0.2f);
        }
    }

    void ResetDash()
    {
        spr.color = Color.white;
        isDashing = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if (!isDashing)
            {
                Instantiate(deathEffect, collider.gameObject.transform.position, Quaternion.identity);
                Hit(50);
            }
        }
    }

    private void Hit(float damage)
    {
        currentHP -= damage;
    }

}
