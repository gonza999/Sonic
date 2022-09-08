using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float waitTime = 2f;
    public float timeToShoot = 0.5f;
    private float time = 0;
    public bool isLeft = true;
    public bool movement = true;
    public Rigidbody2D rigidbody2D;
    public Transform spawnPointBullet;
    public GameObject bulletPrefab;

    private void Update()
    {
        MovementAndWait();
    }

    private void MovementAndWait()
    {
        time += Time.deltaTime;
        if (time>=waitTime)
        {
            Movement();
        }
        if (movement)
        {
            if (isLeft)
            {
                rigidbody2D.velocity = Vector2.left * Enemy.instance.speed;
            }
            else
            {
                rigidbody2D.velocity = Vector2.right * Enemy.instance.speed;
            }
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
            if (time%3==0)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, spawnPointBullet.position, spawnPointBullet.rotation);
    }
    private void Movement()
    {
        movement = !movement;
        time = 0;
    }
}
