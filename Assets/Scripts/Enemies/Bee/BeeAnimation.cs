using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public Transform transform;
    private void Update()
    {
        if (rigidbody2D.velocity!=Vector2.zero)
        {
            animator.SetBool("Fly",true);
        }
        else
        {
            animator.SetBool("Fly",false);
        }

        if (rigidbody2D.velocity.x<=0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }
}
