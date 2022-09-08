using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private void FixedUpdate()
    {
        animator.SetBool("Walk", PlayerMovement.walk);
        animator.SetBool("Jump", PlayerMovement.jump);
        animator.SetBool("Down", PlayerMovement.down);
        animator.SetBool("Run", PlayerMovement.run);
        animator.SetBool("Idle", PlayerMovement.idle);
        animator.SetBool("Dash", PlayerMovement.dash);
        animator.SetBool("Damage", PlayerMovement.damage);
    }

    private void Update()
    {
        Invencibility();
        Damage();
    }

    private void Damage()
    {
        if (animator.GetBool("Damage"))
        {
            if (spriteRenderer.color == Color.white)
            {
                spriteRenderer.color = Color.red;
            }
            else if (spriteRenderer.color == Color.red)
            {
                spriteRenderer.color = Color.white;
            }
        }
    }

    private void Invencibility()
    {
        if (!animator.GetBool("Damage") && Player.instance.invencibility)
        {
            if (spriteRenderer.color.a == 1)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g,
                    spriteRenderer.color.b, 0);
            }
            else if (spriteRenderer.color.a == 0)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g,
                    spriteRenderer.color.b, 1);
            }
        }
        else
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g,
                    spriteRenderer.color.b, 1);
        }
    }
}
