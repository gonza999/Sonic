using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    public float speed = 2;
    public float life = 1;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
