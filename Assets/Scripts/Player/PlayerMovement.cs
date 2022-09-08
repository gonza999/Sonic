using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    private float sizeYCollider;
    public BoxCollider2D boxCollider2D;
    public static bool walk = false;
    public static bool jump = false;
    public static bool down = false;
    public static bool idle = false;
    public static bool run = false;
    public static bool dash = false;
    public static bool damage = false;
    public bool speedBack = false;

    public float force = 2;
    private void Update()
    {
        if (!damage)
        {
            Idle();
            if (!down)
            {
                Walk();
                Back();
            }
            if (IsCheckGround.IsGrounded)
            {
                Down();
                if (!down)
                {
                    Jump();
                }
            }
            PlayerSpeed();
        }
        else
        {
            Damage();
        }
    }

    private void Damage()
    {
        if (IsCheckGround.IsGrounded && !Player.instance.invencibility)
        {
            rigidbody2D.AddForce(Vector2.up * force * Time.deltaTime*10, ForceMode2D.Impulse);
            rigidbody2D.AddForce(Vector2.left * force * Time.deltaTime, ForceMode2D.Impulse);
            Player.instance.invencibility = true;
            Invoke("ChangeDamage",1f);
        }
    }
    private void ChangeDamage()
    {
        damage = false;
        gameObject.GetComponent<SpriteRenderer>().color=Color.white;
    }

    private void Idle()
    {
        if (rigidbody2D.velocity.x == 0 && IsCheckGround.IsGrounded && !down)
        {
            idle = true;
            speedBack = false;
            EnabledCircleCollider(false);
        }
        else
        {
            idle = false;
        }
    }

    private void PlayerSpeed()
    {
        if (walk)
        {
            Player.instance.speed += Time.deltaTime * Player.instance.speedGrowth;
            if (Player.instance.speed >= Player.instance.speedMax)
            {
                Player.instance.speed = Player.instance.speedMax;
            }
        }
        else
        {
            Player.instance.speed = Player.instance.speedDefault;
        }
        if (Math.Abs(rigidbody2D.velocity.x) >= 23)
        {
            dash = true;
            Player.instance.speedGrowth = 6;
        }
        else if (Math.Abs(rigidbody2D.velocity.x) >= 7 && Math.Abs(rigidbody2D.velocity.x) < 23)
        {
            dash = false;
            run = true;
            Player.instance.speedGrowth = 4;
        }
        else if (Math.Abs(rigidbody2D.velocity.x) <= 7)
        {
            run = false;
            Player.instance.speedGrowth = 1;
        }
    }
    private void Down()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            down = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            down = false;
            walk = false;
        }
    }
    private void EnabledCircleCollider(bool enabled)
    {
        boxCollider2D.enabled = !enabled;
        gameObject.GetComponent<CircleCollider2D>().enabled = enabled;
    }

    private void FixedUpdate()
    {
        if (jump || down)
        {
            EnabledCircleCollider(true);
        }
    }
    private void Jump()
    {
        if (Input.GetKey(KeyCode.S))
        {
            walk = false;
            jump = true;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Player.instance.forceJump);
        }
        else
        {
            jump = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            jump = false;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
    private void Back()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            walk = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if (speedBack)
            {
                Player.instance.speed = -rigidbody2D.velocity.x;
                speedBack = false;
            }
            rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Player.instance.speed, rigidbody2D.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            walk = false;
            speedBack = true;
        }
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            walk = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (speedBack)
            {
                Player.instance.speed = rigidbody2D.velocity.x;
                speedBack = false;
            }
            rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Player.instance.speed, rigidbody2D.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            walk = false;
            speedBack = true;
        }
    }
}
