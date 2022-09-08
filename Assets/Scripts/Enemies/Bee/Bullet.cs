using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2;
    public Animator animator;
    public float lifeTime = 1;
    private bool damage=false;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        if (!damage)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("damage",true);
            damage = true;
            PlayerMovement.damage = damage;
            Player.instance.CameraShake();
        }
    }
}
